using Microsoft.EntityFrameworkCore;
using webApi.EventPlus.Contexts;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;

namespace webApi.EventPlus.Repositories
{
    public class ComentariosRepository : IComentarioEvento
    {
        private readonly EventContext _eventcontext;

        public ComentariosRepository()
        {
            _eventcontext = new EventContext();
        }

        public ComentariosEvento BuscarPorId(Guid id)
        {
            try
            {
                return _eventcontext.ComentariosEvento.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentariosEvento comentario)
        {
            try
            {
                _eventcontext.ComentariosEvento.Add(comentario);
                _eventcontext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            _eventcontext.ComentariosEvento.Where(i => i.IdComentario == id).ExecuteDelete();
        }

        public List<ComentariosEvento> Listar()
        {
            try
            {
                return _eventcontext.ComentariosEvento.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
