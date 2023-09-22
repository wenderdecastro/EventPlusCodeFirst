using Microsoft.EntityFrameworkCore;
using webApi.EventPlus.Contexts;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;

namespace webApi.EventPlus.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly EventContext _eventContext;

        public PresencaRepository()
        {
            _eventContext = new EventContext();
        }

        public List<PresencaEvento> ListarPresencas(Guid usuarioId)
        {
            return _eventContext.PresencaEvento.Where(p => p.IdUsuario == usuarioId).ToList();
        }
        public PresencaEvento ParticiparEvento(Guid eventoID, Guid usuarioId)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Find(eventoID);
                Usuario usuarioBuscado = _eventContext.Usuario.Find(usuarioId);

                PresencaEvento novaPresenca;


                if (eventoBuscado != null && usuarioBuscado != null)
                {
                    novaPresenca = new PresencaEvento()
                    {
                        IdEvento = eventoID,
                        IdUsuario = usuarioId,
                        Situacao = true,
                        Evento = eventoBuscado,
                        Usuario = usuarioBuscado
                    };

                    _eventContext.PresencaEvento.Add(novaPresenca);
                    _eventContext.SaveChanges();    
                    return novaPresenca;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void CancelarParticipacao(Guid eventoId, Guid usuarioId)
        {
            try
            {
                _eventContext.PresencaEvento.Where(p => p.IdUsuario == usuarioId && p.IdEvento == eventoId).ExecuteDelete();
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
