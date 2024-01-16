using BitrixApiNet.Api;
using BitrixApiNet.Item.Crm;
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
    public class DealFactory : Base<DealItem>
    {
        public DealFactory(ApiService apiService)
            : base(apiService, 1, "Deal", "D", "CRM_DEAL")
        {

        }

        public new DealItem Get(int id)
        {
            return GetData<DealItem>(id) ?? new DealItem();
        }

        public new ICollection<DealItem> GetItems()
        {
            return GetItems(new QueryParameters());
        }
        public new ICollection<DealItem> GetItems(QueryParameters? queryParameters)
        {
            return GetList<DealItem>(queryParameters);
        }
    }
}
