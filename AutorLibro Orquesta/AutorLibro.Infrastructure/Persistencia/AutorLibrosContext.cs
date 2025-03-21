using AutorLibro.Domain.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorLibro.Infrastructure.Persistencia
{
    public class AutorLibrosContext : DbContext
    {
        public AutorLibrosContext(DbContextOptions<AutorLibrosContext> options) : base(options)
        {

        }



        public DbSet<AutorLibros> AutorLibros { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
