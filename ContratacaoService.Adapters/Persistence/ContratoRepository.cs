using ContratacaoService.Adapters.Data;
using ContratacaoService.Core.Domain.Entities;
using ContratacaoService.Core.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Adapters.Persistence
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly ContratacaoDbContext _context;

        public ContratoRepository(ContratacaoDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Contrato contrato)
        {
            // Se o contrato for novo, adiciona. Se já existe, atualiza.
            // EF Core rastreia isso automaticamente, mas pode ser explícito:
            if (contrato.Id == Guid.Empty) // ou um método IsTransient() na entidade
            {
                _context.Contratos.Add(contrato);
            }
            else
            {
                _context.Contratos.Update(contrato);
            }
            await _context.SaveChangesAsync();
        }

        public Task<Contrato?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }        
    }
}
