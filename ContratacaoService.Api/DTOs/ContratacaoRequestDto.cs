namespace ContratacaoService.Api.DTOs
{
    public class ContratacaoRequestDto
    {
        public required string PropostaId { get; set; }        
        public DateTime? DataContratacao { get; set; }
    }
}
