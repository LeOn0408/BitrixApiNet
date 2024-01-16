using BitrixApiNet.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Factory.Crm.Smart
{
    internal class Item : Base
    {
        public Item(ApiService apiService, int entityTypeId) 
            : base(apiService, entityTypeId, "item")
        {
        }
    }
}
