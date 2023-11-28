using AutenticacaoAutorizacao.Models;
using System.Net.Http.Json;

namespace AutenticacaoAutorizacao.Client.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Categoria>> GetAllCategorias()
        {
            var lista = await _httpClient.GetFromJsonAsync<List<Categoria>>("api/categorias");

            return lista;
        }
    }
}
