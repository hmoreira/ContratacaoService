namespace ContratacaoService.Core.Application.DTOs
{
    public class ContratarPropostaDto 
    {
        public Guid PropostaId { get; private set; }        
        public DateTime? DataContratacao { get; private set; }
        public ContratarPropostaDto(Guid propostaId, DateTime? dataContratacao)
        {
            PropostaId = propostaId;            
            DataContratacao = dataContratacao;
        }
    }
}
