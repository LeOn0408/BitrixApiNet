using BitrixApiNet.Api;
using Newtonsoft.Json;

namespace BitrixApiNet.Item
{
    public class Lead : EntityItem
    {
        [JsonProperty("TITLE")]
        public string? Title { get; set; }
    }
}