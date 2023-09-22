using Microsoft.EntityFrameworkCore;
using webApi.EventPlus.Contexts;
using webApi.EventPlus.Domains;
using webApi.EventPlus.Interfaces;

namespace webApi.EventPlus.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventcontext;

        public InstituicaoRepository()
        {
            _eventcontext = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao instituicaoBuscada = _eventcontext.Instituicao.Find(id);
            if (instituicaoBuscada != null)
            {
                try
                {
                    instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                    instituicaoBuscada.CPNJ = instituicao.CPNJ;
                    instituicaoBuscada.Endereco = instituicao.Endereco;

                    _eventcontext.Instituicao.Update(instituicaoBuscada);
                    _eventcontext.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _eventcontext.Instituicao.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventcontext.Instituicao.Add(instituicao);
                _eventcontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            _eventcontext.Instituicao.Where(i => i.IdInstituicao == id).ExecuteDelete();
        }

        public List<Instituicao> Listar()
        {
            try
            {
                return _eventcontext.Instituicao.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
