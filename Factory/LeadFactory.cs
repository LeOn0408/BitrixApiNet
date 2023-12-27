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

namespace BitrixApiNet.Factory
{
    public class LeadFactory : FactoryBase
    {
        internal LeadFactory(ApiClient apiClient)
            : base(apiClient, Module.CRM, "lead")
        {

        }

        public override int CreateItem(EntityItem item)
        {
            throw new NotImplementedException();
        }

        public override Lead Get(int id)
        {
            return GetLeadData<Lead>(id);
        }
        public override T Get<T>(int id)
        {
            return GetLeadData<T>(id);
        }

        public override List<EntityItem> GetItems(int id)
        {
            throw new NotImplementedException();
        }

        public override List<T> GetItems<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override bool RemoveItem(EntityItem item)
        {
            throw new NotImplementedException();
        }

        private T GetLeadData<T>(int id)
        {
            var result = SendPostAsync("get", new { id }).Result;
            var leadData = JsonConvert.DeserializeObject<ResultModel<T>>(result).Result;
            return leadData;
        }
    }
}
