using AutoMapper;
using MediatR;
using AutorLibro.Domain.Interfaces;
using AutorLibro.Application.DTOs;

namespace AutorLibro.Application.Comandos
{
    public class ConsultaFiltro
    {
        public class Ejecuta : IRequest<AutorLibrosDto>
        {
            public int AutorLibroId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, AutorLibrosDto>
        {
            private readonly IAutorLibrosRepositorio _repositorio;
            private readonly IMapper _mapper;

            public Manejador(IAutorLibrosRepositorio repositorio, IMapper mapper)
            {
                _repositorio = repositorio;
                _mapper = mapper;
            }

            public async Task<AutorLibrosDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autor = await _repositorio.GetByIdWithGradosAsync(request.AutorLibroId);
                return _mapper.Map<AutorLibrosDto>(autor);
            }
        }
    }
}