using BitrixApiNet.Api;
using Microsoft.Extensions.DependencyInjection;

namespace BitrixApiNet.Factory;

public class ApiFactory
{
    public delegate void Callback(string result);

    private static ApiFactory? instance;
    private static readonly object lockObject = new object();

    private ApiFactory(string login, string pass, string urlPoral, string clientId, string clientSecret)
    {
        ApiService = new ApiService(login, pass, urlPoral, clientId, clientSecret);

    }
    public static ApiFactory GetClient(string login, string pass, string urlPoral, string clientId, string clientSecret)
    {
        lock (lockObject)
        {
            instance ??= new ApiFactory(login, pass, urlPoral, clientId, clientSecret);
        }
        return instance;
    }
    /// <summary>
    /// Method in development. It is recommended to create your own service and factory for the required queries
    /// </summary>
    /// <param name="method">REST api method</param>
    /// <param name="body">Query body</param>
    /// <param name="callback">Callback function. The parameters use the string returned by the request</param>
    /// <returns></returns>
    public async Task CallMethod(string method, object body, Callback callback)
    {
        string result = await ApiService.PostAsync(method, body);
        callback(result);
    }

    public ApiService ApiService { get; }




}