using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AutenticacaoAutorizacao.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [JsonIgnore]
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
