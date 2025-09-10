using Microsoft.AspNetCore.Mvc;
using ContratacaoService.Core.Application.Interfaces;
using ContratacaoService.Api.DTOs;
using ContratacaoService.Core.Application.DTOs;

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
                var contratarPropostaDto =
                    new ContratarPropostaDto(contratacaoRequest.PropostaId, contratacaoRequest.DataContratacao);
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
