using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Domain.ValueObjects
{
    public class ClienteContratacao
    {
        public Guid ClienteId { get; private set; }
        public string Nome { get; private set; }

        public ClienteContratacao(Guid clienteId, string nome)
        {
            // Enforce immutability and data integrity
            ClienteId = clienteId;
            Nome = nome;
        }
    }
}
