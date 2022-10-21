namespace MyMarket.ViewsModels
{
    public class CarrinhoComprasRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CarrinhoTotal { get; set; }
        public int CarrinhoCount { get; set; }
        public int ItemCount {get;set;}

        public int DeleteId { get; set; }
    }
}
