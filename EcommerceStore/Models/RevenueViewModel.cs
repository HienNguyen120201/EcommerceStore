using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Models
{
    public class RevenueViewModel
    {
        public int BillId { get; set; }
        public string FullName { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalPrice { get; set; }
        public  string PhoneNumber { get; set; }
    }
}
