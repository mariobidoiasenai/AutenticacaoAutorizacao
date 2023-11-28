using AutenticacaoAutorizacao.Models;
using System.Net.Http.Json;

namespace AutenticacaoAutorizacao.Client.Services
{
    public class ProdutosServices : IProdutosServices
    {
        private readonly HttpClient _httpClient;

        public ProdutosServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProdutoDTO> GetProduto(int id)
        {
            var produto = await _httpClient.GetFromJsonAsync<ProdutoDTO>($"api/produtos/{id}");

            return produto;
        }

        public async Task<List<ProdutoDTO>> GetProdutosPorCategoria(int categoriaId)
        {
            var lista = await _httpClient.GetFromJsonAsync<List<ProdutoDTO>>($"api/produtos/porcategoria/{categoriaId}");

            return lista;
        }



        public async Task<Produto> PostProduto(Produto produto)
        {
            var resposta = await _httpClient.PostAsJsonAsync("api/produtos", produto);
            var t = await resposta.Content.ReadFromJsonAsync<Produto>();
            return t;
        }
    }
}
