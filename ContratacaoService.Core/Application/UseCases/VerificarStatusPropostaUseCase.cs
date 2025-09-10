using ContratacaoService.Core.Application.Interfaces;
using ContratacaoService.Core.Domain.Enums;
using ContratacaoService.Core.Domain.Interfaces.Repositories;
using ContratacaoService.Core.Domain.Interfaces.Services;
using ContratacaoService.Core.Domain.Exceptions;
using ContratacaoService.Core.Application.DTOs;

namespace ContratacaoService.Core.Application.UseCases
{
    public class VerificarStatusPropostaUseCase : IVerificarStatusPropostaUseCase
    {        
        private readonly IPropostaService _propostaService;
        public VerificarStatusPropostaUseCase(IPropostaService propostaService)
        {            
            _propostaService = propostaService; 
        }

        public async Task<PropostaDto?> ExecuteAsync(Guid propostaId)
        {
            return await _propostaService.ConsultarPropostaAsync(propostaId);                            
        }
    }
}
