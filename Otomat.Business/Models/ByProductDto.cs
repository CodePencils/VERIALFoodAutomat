using Otomat.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomat.Business.Models
{
    public class ByProductDto
    {
        public ProductDto Product{ get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int Quantity{ get; set; }

        public double Money{ get; set; }

    }
}
