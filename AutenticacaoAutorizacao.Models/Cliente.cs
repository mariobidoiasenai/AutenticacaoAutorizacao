using System.Text.Json.Serialization;

namespace AutenticacaoAutorizacao.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Numero { get; set; }
        public string CEP { get; set; }

        [JsonIgnore]
        public List<Pedido> Pedidos { get; set; }

    }
}
