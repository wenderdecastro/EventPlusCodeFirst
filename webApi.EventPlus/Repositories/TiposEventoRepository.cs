using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using webApi.EventPlus.Contexts;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;

namespace webApi.EventPlus.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;

        public TiposEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TiposEvento tiposEvento)
        {
            TiposEvento tipoBuscado = BuscarPorId(id);
            try
            {
                if (tipoBuscado != null)
                {
                    tipoBuscado.NomeTipoEvento = tiposEvento.NomeTipoEvento;

                    _eventContext.TiposEvento.Update(tipoBuscado);
                    _eventContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}, erro ao atualizar usuário");
            }
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            return _eventContext.TiposEvento.Find(id);
        }

        public void Cadastrar(TiposEvento tiposEvento)
        {
            try
            {
                _eventContext.TiposEvento.Add(tiposEvento);
                _eventContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Dados inválidos ao cadastrar usuario");
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                _eventContext.TiposEvento.Where(t => t.IdTipoEvento == id).ExecuteDelete();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<TiposEvento> Listar()
        {
            return _eventContext.TiposEvento.ToList();
        }
    }
}
