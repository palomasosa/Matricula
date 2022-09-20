using ClaseModelado1.BD.Data;
using ClaseModelado1.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace claseModelado1.Server.Controllers
{
    [ApiController]
    [Route("api/Especialidades")]
    public class EspecialidadesController : ControllerBase
    {
        private readonly bdc context;
        public EspecialidadesController(bdc bdcontext)
        {
            this.context = bdcontext;
        }
        [HttpGet]   
        public async Task<ActionResult<List<Especialidad>>> Get()
        {
            return await context.Especialidades.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Especialidad>> Get(int id)
        {
            var especialidad = await context.Especialidades.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (especialidad == null)
            {
                return NotFound($"No existe una especialidad de ID={id}");
            }
            return especialidad;
        }

        [HttpGet("EspecialidadPorCodigo/{codigo}")]
        public async Task<ActionResult<Especialidad>> EspecialidadPorCodigo(string codigo)
        {
            var especialidad = await context.Especialidades
                .Where(e => e.Codigo == codigo)
                .Include(m => m.Matriculas)
                .FirstOrDefaultAsync();
            if (especialidad == null)
            {
                return NotFound($"No existe una especialidad de codigo={codigo}");
            }
            return especialidad;
        }



        [HttpPost]
        public async Task<ActionResult<int>> Post (Especialidad especialidad)
        {
            try
            {
                context.Especialidades.Add(especialidad);
                await context.SaveChangesAsync();
                return especialidad.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Especialidad especialidad)
        {
            if(id!= especialidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var especialidadSolicitada = context.Especialidades
                .Where(e => e.Id == id).FirstOrDefault();

            if(especialidadSolicitada == null)
            {
                return NotFound("No se encontró la especialidad a modificar");
            }

            especialidadSolicitada.Codigo = especialidad.Codigo;
            especialidadSolicitada.NomEspecialidad = especialidad.NomEspecialidad;

            try
            {
                context.Especialidades.Update(especialidadSolicitada);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Los datos no se han podido actualizar");
            }
        } 

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var especialidadSeleccionada = context.Especialidades.Where(e => e.Id == id).FirstOrDefault();
            if (especialidadSeleccionada == null)
            {
                return NotFound($"No se encontró la especialidad con el id {id}");
            }
            try
            {
                context.Especialidades.Remove(especialidadSeleccionada);
                context.SaveChanges();
                return Ok($"El registro de {especialidadSeleccionada.NomEspecialidad} se ha eliminado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron ser eliminados por :{e.Message}");

            }

        }

    }

}
