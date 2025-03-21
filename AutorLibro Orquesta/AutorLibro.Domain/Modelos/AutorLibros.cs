using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorLibro.Domain.Modelos
{
    public class AutorLibros
    {
        [Key]
        public int AutorLibroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; }


        public ICollection<GradoAcademico> GradoAcademico { get; set; }

    }
}
