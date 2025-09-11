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
            var response = await _httpClient.GetAsync($"api/proposta/{propostaId}"); 
            
            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();
            
            if (string.IsNullOrWhiteSpace(jsonContent) || jsonContent == "{}")
                return null;            

            // Se o conteúdo não estiver vazio, deserialize-o para o DTO.
            var ret = System.Text.Json.JsonSerializer.Deserialize<PropostaDto?>(jsonContent,
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return ret;
        }
    }
}
