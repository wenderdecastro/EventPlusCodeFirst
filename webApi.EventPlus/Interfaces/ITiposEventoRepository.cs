using webApi.EventPlus.Domains;

namespace webApi.EventPlus.Interfaces
{
    public interface ITiposEventoRepository
    {
        void Cadastrar(TiposEvento tiposEvento);
        void Deletar(Guid id);
        List<TiposEvento> Listar();
        TiposEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, TiposEvento tiposEvento);
    }
}
