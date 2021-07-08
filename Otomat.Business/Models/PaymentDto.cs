using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomat.Business.Models
{
    public class PaymentDto
    { 
            [JsonProperty("Id")]
            public int Id { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Refund")]
            public bool Refund { get; set; } 
    }
}
