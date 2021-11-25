using System;

namespace EcommerceStore.Models
{
    public class PaymentDetailViewModel
    {
        public int BillId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalProductPrice { get; set; }
        public string ImgUrl { get; set; }
    }
}