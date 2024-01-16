using BitrixApiNet.Api;
using Newtonsoft.Json;

namespace BitrixApiNet.Item.Crm
{
    public class DealItem : CrmItem
    {
        [JsonProperty("TITLE")]
        public string? Title { get; set; }

        [JsonProperty("CATEGORY_ID")]
        public int? CategoryId { get; set; }

        [JsonProperty("STAGE_ID")]
        public string? StageId { get; set; }
    }
}