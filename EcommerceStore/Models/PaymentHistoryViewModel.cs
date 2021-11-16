using System;

namespace EcommerceStore.Models
{
    public class PaymentHistoryViewModel
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}