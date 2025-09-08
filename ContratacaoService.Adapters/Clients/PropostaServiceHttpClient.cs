using ContratacaoService.Core.Application.DTOs;
using ContratacaoService.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Adapters.Clients
{
    public class PropostaServiceHttpClient : IPropostaService
    {
        public Task<StatusPropostaDto?> ConsultarStatusPropostaAsync(Guid propostaId)
        {
            throw new NotImplementedException();
        }
    }
}
