using ContratacaoService.Core.Application.DTOs;
using ContratacaoService.Core.Domain.Entities;
using ContratacaoService.Core.Domain.Exceptions;
using ContratacaoService.Core.Domain.Interfaces.Repositories;
using ContratacaoService.Core.Domain.Interfaces.Services;

namespace ContratacaoService.Core.Application.UseCases
{
    public class ContratarPropostaUseCase
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IPropostaService _propostaService; // Porta de saída para o serviço de Propostas

        public ContratarPropostaUseCase(IContratoRepository contratoRepository, IPropostaService propostaService)
        {
            _contratoRepository = contratoRepository ?? throw new ArgumentNullException(nameof(contratoRepository));
            _propostaService = propostaService ?? throw new ArgumentNullException(nameof(propostaService));
        }

        public async Task<ContratoDto> ExecutarAsync(ContratarPropostaDto contratarPropostaDto)
        {
            // 1. Comunicar com o PropostaService para verificar status
            var statusProposta = await _propostaService.ConsultarStatusPropostaAsync(contratarPropostaDto.PropostaId);

            // Verificar se a proposta está aprovada
            if (statusProposta == null || statusProposta.Status != "Aprovada") // Assumindo que StatusPropostaDto tem uma propriedade string 'Status'
            {
                throw new DomainException($"A proposta {contratarPropostaDto.PropostaId} não está aprovada ou não pôde ser verificada.");
            }

            // 2. Armazenar informações da contratação
            var novoContrato = new Contrato(contratarPropostaDto.PropostaId, DateTime.UtcNow); // Assuming Contrato constructor takes PropostaId and Date

            await _contratoRepository.AdicionarAsync(novoContrato);

            // Mapear para um DTO de resposta
            var contratoDto = new ContratoDto
            {
                Id = novoContrato.Id,
                PropostaId = novoContrato.PropostaId,
                DataContratacao = novoContrato.DataContratacao
            };

            return contratoDto;
        }
    }
}
