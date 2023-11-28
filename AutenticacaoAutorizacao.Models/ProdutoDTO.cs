namespace AutenticacaoAutorizacao.Models
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string NomeCategoria { get; set; }

        public string UrlImage { get; set; }
    }
}
