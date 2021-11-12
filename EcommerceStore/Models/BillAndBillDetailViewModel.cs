using System.Collections.Generic;

namespace EcommerceStore.Models
{
    public class BillAndBillDetailViewModel
    {
        public List<BillDetailViewModel> ListProduct {  get; set; }
        public int Total {  get; set; }
        public string PaymentMethod {  get; set;}
        public string Name { get; set; }
        public string Hamlet { get; set; }
        public string Village { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Telephone { get; set; }

    }
}
