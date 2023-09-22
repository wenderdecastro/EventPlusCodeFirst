using webApi.EventPlus.Domains;

namespace webApi.EventPlus.Interfaces
{
    public interface IComentarioEvento
    {
        void Cadastrar(ComentariosEvento comentario);
        void Deletar(Guid id);
        List<ComentariosEvento> Listar();
        ComentariosEvento BuscarPorId(Guid id);
    }
}
