using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Entities
{
    public class BillProduct
    {
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalProductPrice { get; set; }

        public Bill Bill { get; set; }
        public Product Product { get; set; }
    }
}
