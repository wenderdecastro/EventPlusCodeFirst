using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Repositories;

namespace webApi.EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly EventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpGet]
        [Authorize(Roles = "administrador, comum")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public IActionResult Cadastrar(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);
                return StatusCode(201, evento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "administrador")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "administrador")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);
                return Ok(eventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "administrador")]
        public IActionResult Atualizar (Guid id, Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);
                return Accepted();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Comentarios/{id}")]
        [Authorize(Roles = "administrador, comum")]
        public IActionResult ListarComentarios(Guid eventoId)
        {
            try
            {
                return Ok(_eventoRepository.ListarComentarios(eventoId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
