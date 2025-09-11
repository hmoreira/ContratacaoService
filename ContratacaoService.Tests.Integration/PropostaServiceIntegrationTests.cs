using ContratacaoService.Adapters.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ContratacaoService.Tests.Integration
{
    public class PropostaServiceIntegrationTests : IClassFixture<PropostaServiceIntegrationFixture>
    {
        private readonly PropostaServiceHttpClient _propostaService;

        public PropostaServiceIntegrationTests(PropostaServiceIntegrationFixture fixture)
        {
            _propostaService = fixture.PropostaService;
        }
        
        [Fact]
        public async Task ConsultarPropostaAsync_DeveRetornarProposta_QuandoIdExistente()
        {
            // Arrange
            var propostaIdExistente = Guid.Parse("5e95eb6b-8b62-4d72-a395-cbe507ddd6ea"); // Substitua por um ID válido no ambiente de teste

            // Act
            var proposta = await _propostaService.ConsultarPropostaAsync(propostaIdExistente);

            // Assert
            Assert.NotNull(proposta);
            Assert.Equal(propostaIdExistente, proposta.PropostaId);
        }
        
        [Fact]
        public async Task ConsultarPropostaAsync_DeveRetornarNull_QuandoIdInexistente()
        {
            // Arrange
            var propostaIdInexistente = Guid.NewGuid();

            // Act
            var proposta = await _propostaService.ConsultarPropostaAsync(propostaIdInexistente);

            // Assert
            Assert.Null(proposta);
        }        
    }

    // Fixture para configurar dependências reais do serviço HTTP
    public class PropostaServiceIntegrationFixture : IDisposable
    {
        public PropostaServiceHttpClient PropostaService { get; }

        private readonly ServiceProvider _serviceProvider;

        public PropostaServiceIntegrationFixture()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // Output the value to the test output or debug window
            var baseUrl = configuration["Services:PropostaService:BaseUrl"];
            Console.WriteLine($"Loaded BaseUrl: {baseUrl}");            

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            services.AddHttpClient<PropostaServiceHttpClient>((provider, client) =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                var baseUrl = configuration["Services:PropostaService:BaseUrl"];
                client.BaseAddress = new Uri(baseUrl);
            });

            _serviceProvider = services.BuildServiceProvider();
            PropostaService = _serviceProvider.GetRequiredService<PropostaServiceHttpClient>();
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
