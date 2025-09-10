using ContratacaoService.Core.Domain.Entities;

namespace ContratacaoService.Core.Domain.Interfaces.Repositories
{
    public interface IContratoRepository
    {
        Task AdicionarAsync(Contrato contrato);        
    }
}
