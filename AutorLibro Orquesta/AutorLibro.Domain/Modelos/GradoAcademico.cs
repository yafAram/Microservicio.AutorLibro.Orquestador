using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorLibro.Domain.Modelos
{
    public class GradoAcademico
    {
        [Key]
        public int GradoAcademicoId { get; set; }
        public string Nombre { get; set; }
        public string CentroAcademico { get; set; }
        public DateTime FechaGrado { get; set; }
        public string GradoAcademicoGuid { get; set; }

        public int AutorLibroId { get; set; }
        public AutorLibros AutorLibro { get; set; }
    }
}
