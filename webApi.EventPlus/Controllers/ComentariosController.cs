using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;
using webApi.EventPlus.Repositories;

namespace webApi.EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosController : ControllerBase
    {
        private IComentarioEvento _comentarioRepository;

        public ComentariosController()
        {
            _comentarioRepository = new ComentariosRepository();
        }

        [Authorize(Roles = "comum")]
        [HttpPost]
        public IActionResult Adicionar(ComentariosEvento comentario)
        {

            try
            {
                _comentarioRepository.Cadastrar(comentario);

                return StatusCode(201, comentario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "administrador, comum")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_comentarioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpDelete]
        [Authorize(Roles = "administrador, comum")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioRepository.Deletar(id);
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
                ComentariosEvento comentarioBuscado = _comentarioRepository.BuscarPorId(id);

                if (comentarioBuscado == null)
                {
                    return NotFound("Objeto não encontrado");
                }

                return Ok(comentarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
