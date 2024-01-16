using BitrixApiNet.Api;
using BitrixApiNet.Item;
using BitrixApiNet.Item.Crm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Factory
{
    public class UserFactory
    {
        private readonly ApiService _apiService;

        public UserFactory(ApiService apiService)
        {
            _apiService = apiService;
        }

        public ICollection<UserItem> GetUsers()
        {
            return List<UserItem>(new QueryParameters());
        }

        public ICollection<UserItem> GetUsers(QueryParameters? queryParameters)
        {
            return List<UserItem>(queryParameters);
        }

        public ICollection<T> GetUsers<T>() where T : ItemBase
        {
            return List<T>(new QueryParameters());
        }

        public ICollection<T> GetUsers<T>(QueryParameters? queryParameters) where T : ItemBase
        {
            return List<T>(queryParameters);
        }

        private protected List<P> List<P>(QueryParameters? queryParameters) where P : ItemBase
        {
            return PrepareAndSendData<P>(queryParameters, "get");
        }

        private protected List<P> PrepareAndSendData<P>(QueryParameters? queryParameters, string method) where P:ItemBase
        {
            var list = new List<P>();
            int lastId = 0;
            var filter = queryParameters?.Filter ?? new();
            filter.Add(">ID", lastId.ToString());
            
            while (true)
            {
                //TODO:Realize work with bitrix constraints
                Thread.Sleep(1000);
                
                var body = new
                {
                    queryParameters?.Filter,
                    start = -1,
                    order = new { ID = "ASC" },
                };
                string responseString = SendPostAsync(method, body).Result;
                var response = JsonConvert.DeserializeObject<ResultData<List<P>>>(responseString);

                if (response is null || response.Result is null)
                {
                    break;
                }
                if(response.Result.LastOrDefault() is null)
                {
                    break;
                }
                if(lastId > (int)response.Result.LastOrDefault().Id)
                    break;

                lastId = (int)response.Result.LastOrDefault().Id;
                filter[">ID"] = lastId.ToString();

                list.AddRange(response.Result);
            }
            
            
            return list;
        }

        private protected async Task<string> SendPostAsync(string method, object body)
        {
            var jsonResult = _apiService.PostAsync($"user.{method}", body);

            return await jsonResult;
        }
    }
}
