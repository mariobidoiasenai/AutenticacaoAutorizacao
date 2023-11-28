namespace AutenticacaoAutorizacao.Models
{
    public class PedidoInfoDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set;}
        public string NomeTransportadora { get; set; }
        public string CEP { get; set; }
        public string Numero { get;set; }

        public Endereco Endereco { get; set; }
        public List<ItemPedidoDTO> ItemPedidoDTOs { get; set; }

        public float TotalPedido => ItemPedidoDTOs.Sum(i => i.TotalItem);
    }
}
