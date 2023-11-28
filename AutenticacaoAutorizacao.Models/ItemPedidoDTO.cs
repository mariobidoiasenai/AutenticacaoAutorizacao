namespace AutenticacaoAutorizacao.Models
{
    public class ItemPedidoDTO
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public float PrecoUnitario { get; set; }
        public float TotalItem => Quantidade * PrecoUnitario;

    }
}
