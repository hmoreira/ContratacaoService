using ContratacaoService.Core.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Domain.Interfaces.Services
{
    public interface IPropostaService
    {
        Task<StatusPropostaDto?> ConsultarStatusPropostaAsync(Guid propostaId);
    }
}
