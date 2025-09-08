using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratacaoService.Adapters.Data
{
    public class ContratacaoDbContextFactory : IDesignTimeDbContextFactory<ContratacaoDbContext>
    {
        public ContratacaoDbContext CreateDbContext(string[] args)
        {
            // Se você usar um arquivo appsettings.json:
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // O diretório atual será o do projeto infra
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ContratacaoDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ContratacaoDbContext(optionsBuilder.Options);
        }
    }
}
