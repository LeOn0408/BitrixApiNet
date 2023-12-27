using BitrixApiNet.Api;
using BitrixApiNet.Item;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Factory
{
    public abstract class FactoryBase
    {
        private readonly ApiClient _apiClient;
        private readonly Module _module;
        private readonly string _entityName;

        public abstract EntityItem Get(int id);
        public abstract T Get<T>(int id);

        public abstract List<EntityItem> GetItems(int id);
        public abstract List<T> GetItems<T>(int id);

        public abstract int CreateItem(EntityItem item);

        public abstract bool RemoveItem(EntityItem item);


        protected FactoryBase(ApiClient apiClient, Module module, string entityName)
        {
            _apiClient = apiClient;
            _module = module;
            _entityName = entityName;
        }

        private protected async Task<string> SendPostAsync(string method, object body)
        {
            var jsonResult = _apiClient.PostAsync($"{_module}.{_entityName}.{method}", body);

            return await jsonResult;
        }
    }
}
