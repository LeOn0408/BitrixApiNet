using BitrixApiNet.Api;
using BitrixApiNet.Factory;

namespace BitrixApiNet.Service
{
    public interface IEntityService
    {
        FactoryBase Create(ApiClient apiClient);
    }
}