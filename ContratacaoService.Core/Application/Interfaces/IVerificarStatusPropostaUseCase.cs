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
        Task<StatusPropostaEnum?> ExecuteAsync(string propostaId);
    }
}
