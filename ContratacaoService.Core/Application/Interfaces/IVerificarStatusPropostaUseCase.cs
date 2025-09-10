using ContratacaoService.Core.Application.DTOs;
using ContratacaoService.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Application.Interfaces
{
    public interface IVerificarStatusPropostaUseCase
    {        
        Task<PropostaDto?> ExecuteAsync(Guid propostaId);
    }
}
