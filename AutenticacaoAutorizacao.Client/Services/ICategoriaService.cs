using AutenticacaoAutorizacao.Models;

namespace AutenticacaoAutorizacao.Client.Services
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetAllCategorias();
    }
}