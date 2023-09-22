using Microsoft.EntityFrameworkCore;
using webApi.EventPlus.Contexts;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;

namespace webApi.EventPlus.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;


        public TiposUsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TiposUsuario tiposUsuario)
        {
            try
            {
                TiposUsuario? tipoUsuario = _eventContext.TiposUsuario.Find(id);

                if (tipoUsuario != null)
                {
                    tipoUsuario.NomeTipoUsuario = tiposUsuario.NomeTipoUsuario;

                    _eventContext.Update(tipoUsuario);

                    _eventContext.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TiposUsuario.Find(id);
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TiposUsuario.Add(tipoUsuario);

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
                _eventContext.TiposUsuario.Where(t => t.IdTipoUsuario == id).ExecuteDelete();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<TiposUsuario> Listar()
        {
            return _eventContext.TiposUsuario.ToList();
        }
    }
}
