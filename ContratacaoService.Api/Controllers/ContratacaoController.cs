using ContratacaoService.Api.DTOs;
using ContratacaoService.Core.Application.DTOs;
using ContratacaoService.Core.Application.Interfaces;
using ContratacaoService.Core.Domain.Enums;
using ContratacaoService.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ContratacaoService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratacaoController : ControllerBase
    {
        private readonly IContratarPropostaUseCase _contratarProposta;
        private readonly IVerificarStatusPropostaUseCase _verificarStatusProposta;
        public ContratacaoController(IContratarPropostaUseCase contratarProposta, IVerificarStatusPropostaUseCase verificarStatusProposta)
        {
            _contratarProposta = contratarProposta;
            _verificarStatusProposta = verificarStatusProposta;
        }



        // GET api/<ContratacaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public async Task<IResult> Post([FromBody] ContratacaoRequestDto contratacaoRequest)
        {
            try
            {
                Guid guidProposta;
                DateTime dataContratacao;

                if (!Guid.TryParse(contratacaoRequest.PropostaId, out guidProposta))
                    Results.BadRequest("Id da proposta inválido");                
                if (contratacaoRequest.DataContratacao.HasValue)
                    dataContratacao = contratacaoRequest.DataContratacao.Value;
                else
                    dataContratacao = DateTime.UtcNow;

                var contratarPropostaDto =
                    new ContratarPropostaDto(guidProposta, dataContratacao);

                await _contratarProposta.ExecutarAsync(contratarPropostaDto);                    
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }
}
