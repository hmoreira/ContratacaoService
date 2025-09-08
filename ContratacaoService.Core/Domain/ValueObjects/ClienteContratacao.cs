using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Domain.ValueObjects
{
    public class ClienteContratacao // Exemplo de Value Object ou Entidade para os dados do contrato
    {
        public Guid ClienteId { get; set; } // O ID do cliente original
        public required string NomeCompleto { get; set; } // Detalhes que vieram da proposta ou de um serviço de cliente
        public required string Endereco { get; set; }
        // ... outros dados necessários para o contrato
    }
}
