using Microsoft.EntityFrameworkCore;
using webApi.EventPlus.Contexts;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;
using webApi.EventPlus.Utils.Criptografia;

namespace webApi.EventPlus.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;


        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario.Find(id);

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.NomeUsuario = usuario.NomeUsuario;
                    usuarioBuscado.Email = usuario.Email;

                    usuarioBuscado.Senha = Criptografia.GerarHash(usuario.Senha!);
                    _eventContext.Update(usuarioBuscado);

                    _eventContext.SaveChanges();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(Usuario usuario)
        {
            try
            {

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        NomeUsuario = u.NomeUsuario,
                        IdTipoUsuario = u.IdTipoUsuario,
                        Email = u.Email,
                        Senha = u.Senha,

                        TiposUsuario = new TiposUsuario
                        {
                            NomeTipoUsuario = u.TiposUsuario!.NomeTipoUsuario
                        }
                    })
                    .FirstOrDefault(u => u.Email == usuario.Email);


                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.VerificarHash(usuario.Senha, usuarioBuscado.Senha);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }

                    return null;

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        NomeUsuario = u.NomeUsuario,
                        IdTipoUsuario = u.IdTipoUsuario,
                        Email = u.Email,

                        TiposUsuario = new TiposUsuario
                        {
                            NomeTipoUsuario = u.TiposUsuario!.NomeTipoUsuario
                        }
                    })
                    .FirstOrDefault(u => u.IdUsuario == id);

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (usuarioBuscado != null)
                    return usuarioBuscado;

                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

                _eventContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;

            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                _eventContext.Usuario.Where(u => u.IdUsuario == id).ExecuteDelete();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<Usuario> Listar()
        {
            return _eventContext.Usuario.ToList();
        }

    }
}
