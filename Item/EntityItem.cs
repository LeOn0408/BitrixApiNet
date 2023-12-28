using BitrixApiNet.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Item
{
    public class EntityItem
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("ORIGINATOR_ID")]
        public string? OriginatorId { get; set; }

        [JsonProperty("ORIGIN_ID")]
        public string? OriginId { get; set; }
    }
}
