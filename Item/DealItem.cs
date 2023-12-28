using BitrixApiNet.Api;
using Newtonsoft.Json;

namespace BitrixApiNet.Item
{
    public class LeadItem : EntityItem
    {
        [JsonProperty("TITLE")]
        public string? Title { get; set; }
    }
}