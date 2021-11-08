using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Models
{
    public class DescriptionViewModel
    {
        public int DescId { get; set; }
        public int ProductId { get; set; }
        public string Desc { get; set; }
        public string ImgUrl { get; set; }
    }
}
