using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;
using webApi.EventPlus.Repositories;
using webApi.EventPlus.Utils.Criptografia;

namespace webApi.EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepo;

        public UsuarioController()
        {
            _usuarioRepo = new UsuarioRepository();
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _usuarioRepo.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("/BuscarPorLogin")]
        [Authorize(Roles = "administrador, moderador")]
        public IActionResult BuscarPorLogin(Usuario usuario)
        {
            try
            {
                //usuario.Senha = Criptografia.GerarHash(usuario.Senha);

                Usuario usuarioBuscado = _usuarioRepo.BuscarPorEmailESenha(usuario);

                if (usuarioBuscado != null)
                    return Ok(usuarioBuscado);

                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "administrador")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepo.BuscarPorId(id);

                if (usuarioBuscado != null)
                    return Ok(usuarioBuscado);

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepo.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Authorize(Roles = "administrador")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepo.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "administrador")]
        public IActionResult Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                _usuarioRepo.Atualizar(id, usuario);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
