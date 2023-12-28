using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Api
{
    //TODO: Implement an error handler
    internal class ResultData<T>
    {
        [JsonProperty("result")]
        public T? Result { get; set; }

        [JsonProperty("time")]
        public TimeResult? TimeResult { get; set; }
        //next total
        [JsonProperty("next")]
        public int Next { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }  
    }
    
}
