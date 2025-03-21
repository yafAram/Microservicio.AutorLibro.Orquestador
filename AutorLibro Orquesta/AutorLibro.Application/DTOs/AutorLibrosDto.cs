using AutorLibro.Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorLibro.Application.DTOs
{
    public class AutorLibrosDto
    {
        public int AutorLibroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<GradoAcademico> GradoAcademico { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
