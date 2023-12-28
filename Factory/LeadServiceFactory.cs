using BitrixApiNet.Api;
using BitrixApiNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Factory
{
    public class LeadServiceFactory : IEntityServiceFactory
    {
        public EntityServiceBase Create(ApiService _apiService)
        {
            return new LeadService(_apiService);
        }
    }
}
