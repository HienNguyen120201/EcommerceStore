using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Models
{
    public class AdminProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string ImgUrl { get; set; }
        public int  Rating { get; set; }
    }
}
