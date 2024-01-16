using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet
{
    public class QueryParameters
    {
        public Dictionary<string, string>? Filter { get; set; }
        public string[]? Select { get; set; }
    }
}
