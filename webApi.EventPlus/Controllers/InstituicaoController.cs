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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Instituicao instituicao)
        {

            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

                return StatusCode(201, instituicao);
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
                return Ok(_instituicaoRepository.Listar());
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
                _instituicaoRepository.Deletar(id);
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
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                if (instituicaoBuscada == null)
                {
                    return NotFound("Objeto não encontrado");
                }

                return Ok(instituicaoBuscada);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public IActionResult Atualizar(Guid id, Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicao);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
