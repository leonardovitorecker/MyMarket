namespace MyMarket.Models
{
    public class DtoProduto
    {
        public int id { get; set; }
        public string nomeProduto { get; set; }
        public byte[]? arquivo { get; set; }
        public string? imagem { get; set; }
        public decimal valorVenda { get; set; }
        public string nomecategoria { get; set; }
        public int estoque { get; set; }
        public int categoriaid { get; set; }
        public DateTime dataCadastro { get; set; } = DateTime.Now;
        public DateTime dataAlteracao { get; set; } = DateTime.Now;
    }
}
