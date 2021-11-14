using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Models
{
    public class PaymentDetailViewModel
    {
        public int BillId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string Url { get; set; }
    }
}
