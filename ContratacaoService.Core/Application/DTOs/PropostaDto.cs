using ContratacaoService.Core.Domain.Enums;

namespace ContratacaoService.Core.Application.DTOs
{
    public class PropostaDto
    {
        public Guid PropostaId { get; set; }
        public StatusPropostaEnum Status { get; set; }
    }
}
