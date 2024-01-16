using BitrixApiNet.Api;
using Newtonsoft.Json;

namespace BitrixApiNet.Item.Crm
{
    public class LeadItem : CrmItem
    {
        [JsonProperty("TITLE")]
        public string? Title { get; set; }
    }
}