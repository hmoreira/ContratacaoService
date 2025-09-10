using ContratacaoService.Core.Application.DTOs;
using ContratacaoService.Core.Domain.Enums;
using ContratacaoService.Core.Domain.Exceptions;
using ContratacaoService.Core.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace ContratacaoService.Adapters.Clients
{
    public class PropostaServiceHttpClient : IPropostaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _propostaApiBaseUrl;        

        public PropostaServiceHttpClient(HttpClient httpClient, IConfiguration configuration)
        {            
            _httpClient = httpClient;
            
            _propostaApiBaseUrl = configuration["Services:PropostaService:BaseUrl"];
            _httpClient.BaseAddress = new Uri(_propostaApiBaseUrl);
        }        

        public async Task<StatusPropostaEnum?> ConsultarStatusPropostaAsync(string propostaId)
        {
            Guid guidProposta;
            if (!Guid.TryParse(propostaId, out guidProposta))
                throw new Exception("Id da proposta inválido");

            var response = await _httpClient.GetAsync($"api/proposta/{propostaId}/status"); 
            response.EnsureSuccessStatusCode(); // Lança exceção se o status não for de sucesso

            var status = await response.Content.ReadFromJsonAsync<StatusPropostaEnum?>(); 

            if (status == null)
                throw new InvalidOperationException("Não foi possível obter o status da proposta do serviço de Proposta.");            

            return status;
        }
    }
}
