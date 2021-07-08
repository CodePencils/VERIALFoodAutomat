using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomat.Business.Enum
{
    public class ProductType
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DrinkOption")]
        public int? DrinkOption { get; set; }
    }
}
