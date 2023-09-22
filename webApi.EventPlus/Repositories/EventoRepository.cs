using Microsoft.EntityFrameworkCore;
using webApi.EventPlus.Contexts;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;

namespace webApi.EventPlus.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id);
            
            if (eventoBuscado != null)
            {
                try
                {
                    eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.Instituicao = evento.Instituicao;
                    eventoBuscado.Descricao = evento.Descricao;
                    
                    _eventContext.Update(eventoBuscado);
                    _eventContext.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public Evento BuscarPorId(Guid id)
        {
            return _eventContext.Evento.Find(id);
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Deletar(Guid id)
        {
            _eventContext.Evento.Where(e => e.IdEvento == id).ExecuteDelete();
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();
        }

        public List<ComentariosEvento> ListarComentarios(Guid eventoId)
        {
            return _eventContext.ComentariosEvento.Where(c => c.IdEvento == eventoId).ToList();
        }

        
    }
}
