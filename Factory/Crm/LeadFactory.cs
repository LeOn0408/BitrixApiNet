using BitrixApiNet.Api;
using BitrixApiNet.Item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BitrixApiNet.Factory.Crm
{
    public class LeadFactory : Base<LeadItem>
    {
        public LeadFactory(ApiService apiService)
            : base(apiService, 1, "LEAD", "L", "CRM_LEAD")
        {

        }


        public new LeadItem Get(int id)
        {
            return GetData<LeadItem>(id) ?? new LeadItem();
        }

        public new ICollection<LeadItem> GetItems()
        {
            return GetItems(new QueryParameters());
        }
        public new ICollection<LeadItem> GetItems(QueryParameters? queryParameters)
        {
            return GetList<LeadItem>(queryParameters);
        }

    }
}
