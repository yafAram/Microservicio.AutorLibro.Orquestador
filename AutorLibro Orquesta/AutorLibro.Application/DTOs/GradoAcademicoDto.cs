using AutorLibro.Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorLibro.Application.DTOs
{
    public class GradoAcademicoDto
    {
        public int GradoAcademicoId { get; set; }
        public string Nombre { get; set; }
        public string CentroAcademico { get; set; }
        public DateTime FechaGrado { get; set; }
        public AutorLibros AutorLibro { get; set; }
        public string GradoAcademicoGuid { get; set; }
    }
}
