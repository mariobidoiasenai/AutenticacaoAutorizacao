using AutenticacaoAutorizacao.Models;

namespace AutenticacaoAutorizacao.Client.Services
{
    public interface IProdutosServices
    {
        Task<ProdutoDTO> GetProduto(int id);
        Task<List<ProdutoDTO>> GetProdutosPorCategoria(int categoriaId);
        Task<Produto> PostProduto(Produto produto);
    }
}