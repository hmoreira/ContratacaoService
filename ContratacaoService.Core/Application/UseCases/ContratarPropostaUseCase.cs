using ContratacaoService.Core.Application.DTOs;
using ContratacaoService.Core.Application.Interfaces;
using ContratacaoService.Core.Domain.Entities;
using ContratacaoService.Core.Domain.Enums;
using ContratacaoService.Core.Domain.Exceptions;
using ContratacaoService.Core.Domain.Interfaces.Repositories;
using ContratacaoService.Core.Domain.Interfaces.Services;

namespace ContratacaoService.Core.Application.UseCases
{
    public class ContratarPropostaUseCase : IContratarPropostaUseCase
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
            var proposta = await _propostaService.ConsultarPropostaAsync(contratarPropostaDto.PropostaId);

            if (proposta == null)
                throw new DomainException($"A proposta {contratarPropostaDto.PropostaId.ToString()} não foi encontrada.");

            if (proposta.Status != StatusPropostaEnum.Aprovada)
                throw new DomainException($"A proposta {proposta.PropostaId.ToString()} não está aprovada e não pode ser contratada.");

            var contrato = Contrato.Criar(proposta.PropostaId, contratarPropostaDto.DataContratacao,
                                          proposta.Status);                        

            await _contratoRepository.AdicionarAsync(contrato);
            
            var contratoDto = new ContratoDto
            {
                Id = contrato.Id,
                PropostaId = contrato.PropostaId,
                DataContratacao = contrato.DataContratacao                
            };

            return contratoDto;
        }
    }
}
