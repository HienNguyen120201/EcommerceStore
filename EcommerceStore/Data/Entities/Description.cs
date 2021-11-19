using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Entities
{
    public class Description
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DescId { get; set; }
        public int ProductId { get; set; }
        public string MainDesc { get; set; }
        public string Desc { get; set; }
        public string ImgUrl { get; set; }
        public Product Product { get; set; }
    }
}
