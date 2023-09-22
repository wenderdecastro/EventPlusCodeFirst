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
    public class PresencaController : ControllerBase
    {
        private readonly PresencaRepository _presencaRepository;

        public PresencaController()
        {
            _presencaRepository = new PresencaRepository();
        }

        [HttpGet("Participacoes")]
        [Authorize(Roles = "administrador, comum")]
        public IActionResult ListarParticipacoes(Guid usuarioId)
        {
            try
            {
                return Ok(_presencaRepository.ListarPresencas(usuarioId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "administrador, comum")]
        public IActionResult ParticiparEvento(Guid eventoId, Guid usuarioId)
        {
            try
            {
                _presencaRepository.ParticiparEvento(eventoId, usuarioId);

                return Accepted();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "administrador, comum")]
        public IActionResult CancelarParticipacao(Guid eventoId, Guid usuarioId)
        {
            try
            {
                _presencaRepository.CancelarParticipacao(eventoId, usuarioId);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
