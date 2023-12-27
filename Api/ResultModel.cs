using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Api
{
    internal class ResultModel<T>
    {
        [JsonProperty("result")]
        public T? Result { get; set; }

        [JsonProperty("time")]
        public TimeResult? TimeResult { get; set; }
    }
}
