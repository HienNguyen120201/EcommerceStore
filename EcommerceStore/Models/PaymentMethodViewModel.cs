using System;

namespace EcommerceStore.Models
{
    public class PaymentMethodViewModel
    {
        public int BillId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Total { get; set; }
        public string PaymentMethod { get; set; }

    }
}