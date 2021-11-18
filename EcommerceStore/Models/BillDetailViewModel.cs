namespace EcommerceStore.Models
{
    public class BillDetailViewModel
    {
        public string ProductName {  get; set; }
        public int ProductPrice {  get; set; }
        public int Quantity {  get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public int TotalProductPrice { get; set; }
        public string SellOff {  get; set; }
    }
}
