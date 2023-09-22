using webApi.EventPlus.Domains;

namespace webApi.EventPlus.Interfaces
{
    public interface IPresencaRepository
    {
        PresencaEvento ParticiparEvento(Guid eventoID, Guid usuarioId);

        void CancelarParticipacao(Guid eventoId, Guid usuarioId);
        List<PresencaEvento> ListarPresencas(Guid usuarioId);

    }
}
