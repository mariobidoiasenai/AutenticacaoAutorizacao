namespace AutenticacaoAutorizacao.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        public List<ItemPedido> ItensPedido { get; set; }

        public int TransportadoraId { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
