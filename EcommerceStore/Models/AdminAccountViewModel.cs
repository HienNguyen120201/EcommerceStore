using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Models
{
    public class AdminAccountViewModel
    {
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public int Point { get; set; }
    }
}
