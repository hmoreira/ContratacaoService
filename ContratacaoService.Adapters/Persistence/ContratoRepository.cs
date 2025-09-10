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
            _context.Contratos.Add(contrato);            
            await _context.SaveChangesAsync();
        }                
    }
}
