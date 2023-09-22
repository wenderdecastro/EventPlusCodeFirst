using webApi.EventPlus.Domains;

namespace webApi.EventPlus.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);
        void Deletar(Guid id);
        List<Evento> Listar();
        Evento BuscarPorId(Guid id);
        void Atualizar(Guid id, Evento evento);
        List<ComentariosEvento> ListarComentarios(Guid eventoId);
    }
}
