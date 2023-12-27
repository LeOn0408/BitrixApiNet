using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitrixApiNet.Api
{
    internal class AccessData
    {
        [JsonProperty("access_token")]
        public string? AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public double ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string? RefreshToken { get; set; }
    }
}
