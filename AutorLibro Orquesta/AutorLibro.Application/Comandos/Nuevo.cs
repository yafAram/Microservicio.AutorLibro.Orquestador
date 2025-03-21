using FluentValidation;
using MediatR;
using AutorLibro.Domain.Modelos;
using AutorLibro.Domain.Interfaces;
using AutorLibro.Application.Orchestration;
using AutoMapper;

namespace AutorLibro.Application.Comandos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string AutorLibroGuid { get; set; }
            public List<GradoAcademicoData> GradoAcademico { get; set; }
        }

        public class GradoAcademicoData
        {
            public string Nombre { get; set; }
            public string CentroAcademico { get; set; }
            public DateTime FechaGrado { get; set; }
            public string GradoAcademicoGuid { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.FechaNacimiento).NotEmpty();
                RuleFor(x => x.AutorLibroGuid).NotEmpty();
                RuleFor(x => x.GradoAcademico).NotNull();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly AutorLibrosOrchestrator _orchestrator;

            public Manejador(AutorLibrosOrchestrator orchestrator)
            {
                _orchestrator = orchestrator;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                await _orchestrator.CrearAutorConValidacionesAsync(
                    request.Nombre,
                    request.Apellido,
                    request.FechaNacimiento,
                    request.AutorLibroGuid,
                    request.GradoAcademico
                );

                return Unit.Value;
            }
        }
    }
}