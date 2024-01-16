using Newtonsoft.Json;

namespace BitrixApiNet.Item
{
    public class ItemBase
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
    }
}