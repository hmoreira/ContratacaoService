using ContratacaoService.Core.Application.DTOs;

namespace ContratacaoService.Core.Domain.Interfaces.Services
{
    public interface IPropostaService
    {
        Task<PropostaDto?> ConsultarPropostaAsync(Guid propostaId);
    }
}
