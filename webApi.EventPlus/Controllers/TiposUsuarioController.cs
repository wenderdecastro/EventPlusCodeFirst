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
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tipoUsuarioRepo;

        public TiposUsuarioController()
        {
            _tipoUsuarioRepo = new TiposUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(TiposUsuario tiposUsuario)
        {
            
            try
            {
                _tipoUsuarioRepo.Cadastrar(tiposUsuario);

                return StatusCode(201, tiposUsuario);
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
                return Ok(_tipoUsuarioRepo.Listar());
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
                _tipoUsuarioRepo.Deletar(id);
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
                TiposUsuario tipoBuscado = _tipoUsuarioRepo.BuscarPorId(id);

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
        public IActionResult Atualizar(Guid id, TiposUsuario usuario)
        {
            try
            {
                _tipoUsuarioRepo.Atualizar(id, usuario);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
