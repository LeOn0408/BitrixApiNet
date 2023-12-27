using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Item
{
    public class EntityItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
