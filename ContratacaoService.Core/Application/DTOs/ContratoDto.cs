using ContratacaoService.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Application.DTOs
{
    public class ContratoDto { 
        public Guid Id { get; set; } 
        public Guid PropostaId { get; set; } 
        public DateTime DataContratacao { get; set; }         
    }
}
