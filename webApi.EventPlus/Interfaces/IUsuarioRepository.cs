using webApi.EventPlus.Domains;

namespace webApi.EventPlus.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Deletar(Guid id);
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        Usuario BuscarPorEmailESenha(Usuario usuario);
        void Atualizar(Guid id, Usuario usuario);
    }
}
