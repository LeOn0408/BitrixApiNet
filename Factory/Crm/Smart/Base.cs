using BitrixApiNet.Api;
using BitrixApiNet.Item.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Factory.Crm.Smart
{
    internal class Base : IBase<SmartBaseItem>
    {
        private readonly ApiService _apiService;
        private readonly int _entityTypeId;
        private readonly string _smarttype;

        public Base(ApiService apiService, int entityTypeId, string smarttype)
        {
            _apiService = apiService;
            _entityTypeId = entityTypeId;
            _smarttype = smarttype;
        }

        public int CreateItem(SmartBaseItem item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public CrmItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<CrmItem> GetItems(QueryParameters queryParameters)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(CrmItem item)
        {
            throw new NotImplementedException();
        }

        private protected async Task<string> SendPostAsync(string method, object body)
        {
            var jsonResult = _apiService.PostAsync($"crm.{_smarttype}.{method}", body);

            return await jsonResult;
        }
    }
}
