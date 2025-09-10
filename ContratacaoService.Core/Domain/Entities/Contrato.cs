using ContratacaoService.Core.Application.DTOs;
using ContratacaoService.Core.Domain.Enums;
using ContratacaoService.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Domain.Entities
{
    public class Contrato
    {
        public Guid Id { get; private set; }
        public Guid PropostaId { get; private set; }
        public DateTime DataContratacao { get; private set; }        

        private Contrato(Guid propostaId, DateTime dataContratacao)
        {
            PropostaId = propostaId;
            DataContratacao = dataContratacao;            
        }        

        public static Contrato Criar(Guid propostaId, DateTime? dataContratacaoP,
                                     StatusPropostaEnum? statusProposta)
        {
            DateTime dataContratacao;
            
            if (propostaId == Guid.Empty)
                throw new DomainException("O ID da proposta é obrigatório.");            
            if (statusProposta != StatusPropostaEnum.Aprovada)
                throw new DomainException($"A proposta {propostaId} não está aprovada e não pode ser contratada.");

            if (!dataContratacaoP.HasValue)
                dataContratacao = DateTime.UtcNow; //considera data atual
            else
                dataContratacao = dataContratacaoP.Value;

            return new Contrato(propostaId, dataContratacao);
        }
    }
}
