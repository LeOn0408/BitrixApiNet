using BitrixApiNet.Api;
using BitrixApiNet.Item;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Factory.Crm
{
    public abstract class Base<T> : IBase<T> where T : EntityItem
    {
        public int EntityTypeId { get; init; }
        public string EntityTypeName { get; init; }
        public string ShortEntityTypeName { get; init; }
        public string EntityTypeUserfield { get; init; }


        private readonly ApiService _apiService;

        public EntityItem Get(int id)
        {
            return GetData<EntityItem>(id) ?? new();
        }

        public ICollection<EntityItem> GetItems(QueryParameters queryParameters)
        {
            return GetList<EntityItem>(queryParameters);
        }

        public ICollection<EntityItem> GetItems()
        {
            return GetItems(new QueryParameters());
        }

        public int CreateItem(T item)
        {
            var body = new
            {
                fields = item,
                @params = new
                {
                    REGISTER_SONET_EVENT = "Y"
                }
            };
            string responseString = SendPostAsync("add", body).Result;
            var response = JsonConvert.DeserializeObject<ResultData<int>>(responseString);
            if (response is null)
                return 0;
            return response.Result;
        }

        public bool DeleteItem(int id)
        {
            var body = new
            {
                id
            };
            string responseString = SendPostAsync("delete", body).Result;
            var response = JsonConvert.DeserializeObject<ResultData<bool>>(responseString);
            if (response is null)
                return false;
            return response.Result;
        }


        public bool UpdateItem(EntityItem item)
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
            var response = JsonConvert.DeserializeObject<ResultData<bool>>(responseString);
            if (response is null)
                return false;
            return response.Result;
        }

        public P Get<P>(int id) where P : new()
        {
            return GetData<P>(id) ?? new();
        }


        public ICollection<P> GetItems<P>(QueryParameters? queryParameters)
        {
            return GetList<P>(queryParameters);
        }
        public ICollection<P> GetItems<P>()
        {
            return GetList<P>(new QueryParameters());
        }
        protected Base(ApiService apiService,
            int entityTypeId,
            string entityTypeName,
            string shortEntityTypeName,
            string entityTypeUserfield)
        {
            _apiService = apiService;
            EntityTypeId = entityTypeId;
            EntityTypeName = entityTypeName;
            ShortEntityTypeName = shortEntityTypeName;
            EntityTypeUserfield = entityTypeUserfield;
        }

        private protected async Task<string> SendPostAsync(string method, object body)
        {
            var jsonResult = _apiService.PostAsync($"crm.{EntityTypeName}.{method}", body);

            return await jsonResult;
        }

        private protected List<P> GetList<P>(QueryParameters? queryParameters)
        {
            var body = new
            {
                queryParameters
            };
            string responseString = SendPostAsync("list", body).Result;
            var response = JsonConvert.DeserializeObject<ResultData<List<P>>>(responseString);

            if (response is null || response.Result is null)
                return new List<P>();
            return response.Result;
        }

        private protected P? GetData<P>(int id)
        {
            var responseString = SendPostAsync("get", new { id }).Result;
            var response = JsonConvert.DeserializeObject<ResultData<P>>(responseString);
            if (response is null || response.Result is null)
                return default;
            return response.Result;
        }

    }
}
