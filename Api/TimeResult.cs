using Newtonsoft.Json;

namespace BitrixApiNet.Api
{
    public class TimeResult
    {
        [JsonProperty("start")]
        public float? Start { get; set; }

        [JsonProperty("finish")]
        public float? Finish { get; set; }

        [JsonProperty("duration")]
        public float? Duration { get; set; }

        [JsonProperty("processing")]
        public float? Processing { get; set; }

        [JsonProperty("date_start")]
        public DateTime? DateStart { get; set; }

        [JsonProperty("date_finish")]
        public DateTime? DateFinish { get; set; }
    }
}