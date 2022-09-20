using ClaseModelado1.BD.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseModelado1.BD.Data
{
    public class bdc : DbContext
    {

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public bdc(DbContextOptions options) : base(options)
        {
        }

        
    }
}
