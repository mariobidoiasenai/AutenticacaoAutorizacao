namespace AutenticacaoAutorizacao.Models
{
    public class Transportadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}
