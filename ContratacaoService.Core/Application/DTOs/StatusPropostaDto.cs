using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Application.DTOs
{
    public class StatusPropostaDto { 
        public Guid PropostaId { get; set; } 
        public required string Status { get; set; } 
    }
}
