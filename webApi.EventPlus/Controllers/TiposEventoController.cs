using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;
using webApi.EventPlus.Repositories;

namespace webApi.EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Roles = "administrador")]
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tipoEventoRepo;

        public TiposEventoController()
        {
            _tipoEventoRepo = new TiposEventoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(TiposEvento tiposEvento)
        {

            try
            {
                _tipoEventoRepo.Cadastrar(tiposEvento);

                return StatusCode(201, tiposEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipoEventoRepo.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepo.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                TiposEvento tipoBuscado = _tipoEventoRepo.BuscarPorId(id);

                if (tipoBuscado == null)
                {
                    return NotFound("Objeto não encontrado");
                }

                return Ok(tipoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public IActionResult Atualizar(Guid id, TiposEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepo.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
