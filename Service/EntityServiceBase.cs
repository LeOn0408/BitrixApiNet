using BitrixApiNet.Api;
using BitrixApiNet.Item;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Service
{
    public abstract class EntityServiceBase
    {
        private readonly ApiService _apiService;
        private readonly Module _module;
        private readonly string _entityName;

        public abstract EntityItem Get(int id);
        public abstract T Get<T>(int id);

        public abstract List<EntityItem> GetItems(int id);
        public abstract List<T> GetItems<T>(int id);

        public abstract int CreateItem(EntityItem item);

        public abstract bool DeleteItem(int id);

        public abstract bool UpdateItem(EntityItem item);

        protected EntityServiceBase(Module module, string entityName, ApiService apiService)
        {
            _apiService = apiService;
            _module = module;
            _entityName = entityName;
        }

        private protected async Task<string> SendPostAsync(string method, object body)
        {
            var jsonResult = _apiService.PostAsync($"{_module}.{_entityName}.{method}", body);

            return await jsonResult;
        }
    }
}
