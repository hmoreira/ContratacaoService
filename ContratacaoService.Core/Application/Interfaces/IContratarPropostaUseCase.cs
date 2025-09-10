using ContratacaoService.Core.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Application.Interfaces
{
    public interface IContratarPropostaUseCase
    {        
        Task<ContratoDto> ExecutarAsync(ContratarPropostaDto criarPropostaDto);
    }
}
