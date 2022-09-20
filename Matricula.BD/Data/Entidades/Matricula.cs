using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseModelado1.BD.Data.Entidades
{
    [Index(nameof(MedicoId),nameof(EspecialidadId), Name = "MatriculaMedicoIdEspecialidadId_UQ", IsUnique =true)]
    public class Matricula : EntityBase
    {
        [Required(ErrorMessage ="El número de matricula es obligatorio")]
        [MaxLength(10, ErrorMessage = "El número de matricula no debe superar los {1} dígitos")]
        public string NumMatricula { get; set; }
        public int MedicoId { get; set; }
        public int EspecialidadId { get; set; }
        public Medico Medico { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}
