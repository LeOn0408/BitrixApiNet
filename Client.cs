using BitrixApiNet.Api;
using BitrixApiNet.Factory;
using BitrixApiNet.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BitrixApiNet;

public class Client
{
    public delegate void Callback(string result);

    private static Client? instance;

    private readonly ApiService? _apiService;
    private static readonly object lockObject = new object();

    private Client(string login, string pass, string urlPoral, string clientId, string clientSecret)
    {
        _apiService = new ApiService(login, pass, urlPoral, clientId, clientSecret);
        
    }
    public static Client GetClient(string login,string pass, string urlPoral, string clientId, string clientSecret)
    {
        lock (lockObject)
        {
            instance ??=  new Client(login,pass,urlPoral, clientId, clientSecret);
        }
        return instance;
    }
    
    /// <summary>
    /// Returns a factory for working with entities
    /// </summary>
    /// <param name="entityFactory">Factory creation service</param>
    /// <returns>Entity Factory</returns>
    public EntityServiceBase GetService(IEntityServiceFactory entityFactory)
    {
        return entityFactory.Create(_apiService);
    }

    /// <summary>
    /// Method in development. It is recommended to create your own service and factory for the required queries
    /// </summary>
    /// <param name="method">REST api method</param>
    /// <param name="body">Query body</param>
    /// <param name="callback">Callback function. The parameters use the string returned by the request</param>
    /// <returns></returns>
    public async Task CallMethod(string method, object body,Callback callback)
    {
        string result = await _apiService.PostAsync(method, body);
        callback(result);
    }
}