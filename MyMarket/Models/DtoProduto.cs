namespace MyMarket.Models
{
    public class DtoProduto
    {
        public int id { get; set; }
        public string nomeProduto { get; set; }
        public string imagem { get; set; }
        public decimal valorVenda { get; set; }

        public int estoque { get; set; }
        public string categoria { get; set; }

    }
}
