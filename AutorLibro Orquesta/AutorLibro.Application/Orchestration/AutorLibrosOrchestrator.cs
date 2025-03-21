using AutorLibro.Application.Comandos;
using AutorLibro.Domain.Interfaces;
using AutorLibro.Domain.Modelos;
using System.Threading.Tasks;

namespace AutorLibro.Application.Orchestration
{
    public class AutorLibrosOrchestrator
    {
        private readonly IAutorLibrosRepositorio _repositorio;

        public AutorLibrosOrchestrator(IAutorLibrosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<AutorLibros> CrearAutorConValidacionesAsync(
            string nombre,
            string apellido,
            DateTime fechaNacimiento,
            string guid,
            List<Nuevo.GradoAcademicoData> grados)
        {
            var autor = new AutorLibros
            {
                Nombre = nombre,
                Apellido = apellido,
                FechaNacimiento = fechaNacimiento,
                AutorLibroGuid = guid,
                GradoAcademico = grados?.Select(g => new GradoAcademico
                {
                    Nombre = g.Nombre,
                    CentroAcademico = g.CentroAcademico,
                    FechaGrado = g.FechaGrado,
                    GradoAcademicoGuid = g.GradoAcademicoGuid
                }).ToList()
            };

            await _repositorio.AddAsync(autor);
            return autor;
        }
    }
}