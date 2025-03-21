using AutorLibro.Application.Comandos;
using AutorLibro.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio.AutorLibro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorLibrosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorLibrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorLibrosDto>>> GetAllAutores()
        {
            var result = await _mediator.Send(new Consulta.Ejecuta());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorLibrosDto>> GetAutorById(int id)
        {
            var result = await _mediator.Send(new ConsultaFiltro.Ejecuta { AutorLibroId = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateAutor([FromBody] Nuevo.Ejecuta data)
        {
            var result = await _mediator.Send(data);
            return CreatedAtAction(nameof(GetAutorById), new { id = result }, result);
        }
    }
}