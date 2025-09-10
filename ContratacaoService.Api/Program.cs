using ContratacaoService.Adapters.Clients;
using ContratacaoService.Adapters.Data;
using ContratacaoService.Adapters.Persistence;
using ContratacaoService.Core.Application.UseCases;
using ContratacaoService.Core.Domain.Interfaces.Repositories;
using ContratacaoService.Core.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using ContratacaoService.Core.Application.Interfaces;

namespace ContratacaoService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ContratacaoDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IContratoRepository, ContratoRepository>();
            builder.Services.AddHttpClient<IPropostaService, PropostaServiceHttpClient>();
            builder.Services.AddScoped<IContratarPropostaUseCase, ContratarPropostaUseCase>();
            builder.Services.AddScoped<IVerificarStatusPropostaUseCase, VerificarStatusPropostaUseCase>();

            builder.Services.AddControllers();   

            var app = builder.Build();            

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
