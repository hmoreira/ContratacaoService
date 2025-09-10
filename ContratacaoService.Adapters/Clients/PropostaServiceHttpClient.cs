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

        public async Task<PropostaDto?> ConsultarPropostaAsync(Guid propostaId)
        {
            var response = await _httpClient.GetAsync($"api/proposta/{propostaId.ToString()}"); 
            response.EnsureSuccessStatusCode(); // Lança exceção se o status não for de sucesso

            return await response.Content.ReadFromJsonAsync<PropostaDto?>(); 
        }
    }
}
