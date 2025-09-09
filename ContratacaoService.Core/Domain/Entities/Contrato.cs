using ContratacaoService.Core.Domain.Enums;
using ContratacaoService.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Domain.Entities
{
    public class Contrato
    {
        public Guid Id { get; set; }
        public Guid PropostaId { get; set; }
        public DateTime DataContratacao { get; set; }
        public StatusContratacaoEnum StatusContratacao { get; set; }
        public ClienteContratacao DadosCliente { get; set; }

        private Contrato() { } // Construtor privado

        public Contrato(Guid propostaId, DateTime dataContratacao)
        {
            Id = Guid.NewGuid();
            PropostaId = propostaId;
            DataContratacao = dataContratacao;
        }
    }
}
