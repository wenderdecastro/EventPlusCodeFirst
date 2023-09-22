using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;
using webApi.EventPlus.Repositories;
using webApi.EventPlus.ViewModels;

namespace webApi.EventPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepo;

        public LoginController()
        {
            _usuarioRepo = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            Usuario userLogin = new Usuario()
            {
                Email = login.Email,
                Senha = login.Senha,
            };

            Usuario usuarioBuscado = _usuarioRepo.BuscarPorEmailESenha(userLogin);

            //1º, define as informações do token (payload), como parametro estão as propriedades do usuário que serão inseridas no token
            if (usuarioBuscado != null)
            {
                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario),
                        new Claim(ClaimTypes.Role, usuarioBuscado.TiposUsuario.NomeTipoUsuario),

            };

                //2º define chave de acesso ao token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key-eventplus.webapi.auth.dev-senai"));

                //3º define as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º Gera o token JWT
                var token = new JwtSecurityToken(
                    // emissor do token
                    issuer: "Event",
                    // destinatario do token
                    audience: "Event",
                    // informações do token
                    claims: claims,
                    // duração do token
                    expires: DateTime.Now.AddMinutes(30),
                    // credenciais que serão utilizadas
                    signingCredentials: creds
                    );

                //retorna um ok e o token JWT
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Email ou senha inválidos");
        }
    }
}
