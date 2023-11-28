using AutenticacaoAutorizacao.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AutenticacaoAutorizacao.Client.Services
{
    public class AutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(LoginRequest request)
        {
            var result = await _httpClient
                .PostAsJsonAsync("api/auth/login", request);

            if (result.IsSuccessStatusCode)
            {
                var token = await result
                        .Content.ReadAsStringAsync();

                return token;
            }

            return string.Empty;
        }
    }
}
