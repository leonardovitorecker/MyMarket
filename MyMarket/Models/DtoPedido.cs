namespace MyMarket.Models
{
    public class DtoPedido
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string produto { get; set; }
        public decimal valorTotal { get; set; }
    }
}
