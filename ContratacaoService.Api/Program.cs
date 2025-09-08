using ContratacaoService.Adapters.Clients;
using ContratacaoService.Adapters.Data;
using ContratacaoService.Adapters.Persistence;
using ContratacaoService.Core.Application.UseCases;
using ContratacaoService.Core.Domain.Interfaces.Repositories;
using ContratacaoService.Core.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddScoped<ContratarPropostaUseCase>();
            builder.Services.AddScoped<VerificarStatusPropostaUseCase>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
