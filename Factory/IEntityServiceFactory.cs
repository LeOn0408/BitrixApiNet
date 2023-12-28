using BitrixApiNet.Api;
using BitrixApiNet.Service;

namespace BitrixApiNet.Factory
{
    public interface IEntityServiceFactory
    {
        EntityServiceBase Create(ApiService? _apiService);
    }
}