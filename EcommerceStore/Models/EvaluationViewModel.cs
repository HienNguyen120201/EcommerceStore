using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Models
{
    public class EvaluationViewModel
    {
        public string Fullname { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime EvalTime { get; set; }
    }
}
