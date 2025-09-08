using ContratacaoService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Core.Domain.Interfaces.Repositories
{
    public interface IContratoRepository
    {
        Task AdicionarAsync(Contrato contrato);
        Task<Contrato?> ObterPorIdAsync(Guid id);
        // Outros métodos...
    }
}
