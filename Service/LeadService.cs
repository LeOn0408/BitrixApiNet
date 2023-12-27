using BitrixApiNet.Api;
using BitrixApiNet.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Service
{
    public class LeadService : IEntityService
    {
        public FactoryBase Create(ApiClient apiClient)
        {
            return new LeadFactory(apiClient);
        }
    }
}
