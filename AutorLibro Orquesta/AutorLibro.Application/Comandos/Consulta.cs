using AutoMapper;
using MediatR;
using AutorLibro.Domain.Interfaces;
using AutorLibro.Application.DTOs;

namespace AutorLibro.Application.Comandos
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<AutorLibrosDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<AutorLibrosDto>>
        {
            private readonly IAutorLibrosRepositorio _repositorio;
            private readonly IMapper _mapper;

            public Manejador(IAutorLibrosRepositorio repositorio, IMapper mapper)
            {
                _repositorio = repositorio;
                _mapper = mapper;
            }

            public async Task<List<AutorLibrosDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autores = await _repositorio.GetAllWithGradosAsync();
                return _mapper.Map<List<AutorLibrosDto>>(autores);
            }
        }
    }
}