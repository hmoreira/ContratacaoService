using ContratacaoService.Core.Application.Interfaces;
using ContratacaoService.Core.Domain.Enums;
using ContratacaoService.Core.Domain.Interfaces.Repositories;
using ContratacaoService.Core.Domain.Interfaces.Services;
using ContratacaoService.Core.Domain.Exceptions;

namespace ContratacaoService.Core.Application.UseCases
{
    public class VerificarStatusPropostaUseCase : IVerificarStatusPropostaUseCase
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IPropostaService _propostaService;
        public VerificarStatusPropostaUseCase(IContratoRepository contratoRepository, IPropostaService propostaService)
        {
            _contratoRepository = contratoRepository;
            _propostaService = propostaService; 
        }

        public async Task<StatusPropostaEnum?> ExecuteAsync(string propostaId)
        {
            return await _propostaService.ConsultarStatusPropostaAsync(propostaId);                            
        }
    }
}
