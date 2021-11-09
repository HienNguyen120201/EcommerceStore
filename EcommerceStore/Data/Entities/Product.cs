using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string ImgUrl { get; set; }
        public int Rating { get; set; }
        public string Special { get; set; }

        public List<Description> Desc { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<BillProduct> BillProducts { get; set; }

    }
}
