using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Entities
{
    public class Bill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }
        public string PaymentMethod { get; set; }

        public int TotalPrice { get; set; }
        public string AddressReceive { get; set; }
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
        public List<BillProduct> Products { get; set; }
    }
}
