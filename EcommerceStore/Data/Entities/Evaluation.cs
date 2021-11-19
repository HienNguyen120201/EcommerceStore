using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Entities
{
    public class Evaluation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EvalID { get; set; }
        public int ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime EvalTime { get; set; }

        public Customer Customer {get;set;}
        public Product Product { get; set; }

    }
}
