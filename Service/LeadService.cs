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

namespace BitrixApiNet.Service
{
    public class LeadService : EntityServiceBase
    {
        internal LeadService(ApiService apiService)
            : base(Module.CRM, "lead", apiService)
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

        private T GetLeadData<T>(int id)
        {
            var result = SendPostAsync("get", new { id }).Result;
            var leadData = JsonConvert.DeserializeObject<ResultModel<T>>(result).Result;
            return leadData;
        }

        public override bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override bool UpdateItem(EntityItem item)
        {
            var id = item.Id;
            var fields = item;
            var body = new
            {
                id,
                fields,
                @params = new
                {
                    REGISTER_SONET_EVENT = "Y"
                }
            };
            string responseString = SendPostAsync("update", body).Result;
            var response = JsonConvert.DeserializeObject<ResultModel<bool>>(responseString);
            if (response is null)
                return false;
            return response.Result;
        }
    }
}
