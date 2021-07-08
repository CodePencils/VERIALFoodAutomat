using Newtonsoft.Json;
using Otomat.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomat.Business.Models
{
    public class ProductDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public object Name { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        [JsonProperty("ProductType")]
        public ProductType ProductType { get; set; }

    }
}
