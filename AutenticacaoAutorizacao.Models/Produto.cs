using System.ComponentModel.DataAnnotations;

namespace AutenticacaoAutorizacao.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public float Preco { get; set; }

        [MaxLength(200)]
        public string Descricao { get; set; } = string.Empty;

        public string UrlImage { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
