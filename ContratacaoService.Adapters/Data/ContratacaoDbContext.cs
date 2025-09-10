using ContratacaoService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Adapters.Data
{
    public class ContratacaoDbContext : DbContext
    {
        public DbSet<Contrato> Contratos { get; set; }

        public ContratacaoDbContext(DbContextOptions<ContratacaoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
