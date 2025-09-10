namespace ContratacaoService.Core.Application.DTOs
{
    public class ContratarPropostaDto 
    {
        public string PropostaId { get; private set; }        
        public DateTime? DataContratacao { get; private set; }
        public ContratarPropostaDto(string propostaId, DateTime? dataContratacao)
        {
            PropostaId = propostaId;            
            DataContratacao = dataContratacao;
        }
    }
}
