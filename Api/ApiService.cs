using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BitrixApiNet.Api;

public class ApiService
{
    private const string BX_OAuthSite = "https://oauth.bitrix.info";

    private string? _accessToken;

    private string? _refreshToken;

    private DateTime _refreshTime;

    private string? _code;

    private CookieContainer? _cookie;

    private readonly string _pass;

    private readonly string _clientSecret;

    private readonly string _urlPortal;

    private readonly string _clientId;

    private readonly string _login;


    internal ApiService(string login, string pass, string urlPortal,string clientId,string clientSecret)
    {
        _urlPortal = urlPortal;
        _clientId = clientId;
        _login=login;
        _pass = pass;
        _clientSecret = clientSecret;

        Task.Factory.StartNew(ConnectAsync);
    }
    private async Task ConnectAsync()
    {
        string bxUri = _urlPortal + "/oauth/authorize/?client_id=" + _clientId;

        HttpClientHandler handler = GetHandler();
        using HttpClient client = GetClient(bxUri, handler);

        var response = await client.GetAsync(bxUri);
        if (response.StatusCode != HttpStatusCode.Found)
        {
            return;
        }

        WriteCode(response);
        WriteCookies(bxUri, handler);

        string bxOAuthUri = $"{_urlPortal}/oauth/token/?grant_type=authorization_code" +
            $"&client_id={_clientId}" +
            $"&client_secret={_clientSecret}" +
            $"&code={_code}";

        await SetTokenAsync(bxOAuthUri);
    }

    private async Task SetTokenAsync(string bxOAuthUri)
    {
        using HttpClient client = GetClient(bxOAuthUri, GetHandler());

        var response = await client.GetAsync(bxOAuthUri);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new FormatException("ErrorLogonBitrixOAuth");
        }

        string responseOAuth = await response.Content.ReadAsStringAsync();

        AccessData? accessData = JsonConvert.DeserializeObject<AccessData>(responseOAuth);
        _accessToken = accessData?.AccessToken;
        _refreshToken = accessData?.RefreshToken;
        _refreshTime = DateTime.Now.AddSeconds(accessData?.ExpiresIn ?? 0);
    }

    private async Task RefreshTokensAsync()
    {
        if (_refreshTime == DateTime.MinValue)
        {
            await ConnectAsync();
            return;
        }

        if (_refreshTime.AddSeconds(-5) < DateTime.Now)
        {
            string bxOAuthUri = $"{_urlPortal}/oauth/token/?grant_type=authorization_code" +
                        $"&client_id={_clientId}" +
                        $"&client_secret={_clientSecret}" +
                        $"&code={_code}";

            await SetTokenAsync(bxOAuthUri);
        }
    }

    private void WriteCode(HttpResponseMessage response)
    {
        var locationUri = response.Headers.Location ?? throw new FormatException("locationUri is null");

        var locationParams = System.Web.HttpUtility.ParseQueryString(locationUri.Query);
        _code = locationParams["Code"];

        if (string.IsNullOrEmpty(_code))
        {
            throw new FormatException("CodeNotFound");
        }
    }

    private void WriteCookies(string bxUri, HttpClientHandler handler)
    {
        var cookies = handler.CookieContainer.GetCookies(new Uri(bxUri));

        _cookie = new CookieContainer();
        foreach (Cookie cookie in cookies)
        {
            _cookie.Add(cookie);
        }
    }

    private HttpClient GetClient(string _urlPortal, HttpClientHandler handler)
    {
        HttpClient client = new(handler);
        client.BaseAddress = new Uri(_urlPortal);
        string bearer = Convert.ToBase64String(Encoding.ASCII.GetBytes(_login + ":" + _pass));

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", bearer);
        return client;
    }

    private HttpClientHandler GetHandler()
    {
        HttpClientHandler handler = new();
        handler.AllowAutoRedirect = false;
        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        if (_cookie is not null)
            handler.CookieContainer = _cookie;
        return handler;
    }

    public async Task<string> PostAsync(string method, object body)
    {
        await RefreshTokensAsync();

        var json = JsonConvert.SerializeObject(body);
        var contentData = new StringContent(json, Encoding.UTF8, "application/json");

        using HttpClient client = GetClient(_urlPortal, GetHandler());

        var url = $"{_urlPortal}/rest/{method}.json?auth={_accessToken}";
        var response = await client.PostAsync(url, contentData);

        return await response.Content.ReadAsStringAsync();
    }
}

