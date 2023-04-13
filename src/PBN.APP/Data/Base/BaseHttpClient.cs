using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using PBN.APP.Data.Interfaces;

namespace PBN.APP.Data.Base;

public abstract class BaseHttpClient<T> : IHttpClient
{
    private readonly HttpClient _httpClient;

    public BaseHttpClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Y> GetAsync<Y>([StringSyntax("Uri")] string requestUri)
    {
        var response = await _httpClient.GetAsync(requestUri);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Y>();
            return result;
        }

        return default;
    }

    public async Task<Y> PostAsync<Y>([StringSyntax("Uri")] string requestUri, HttpContent content)
    {
        var response = await _httpClient.PostAsync(requestUri, content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<Y>();

            return result;
        }

        return default;
    }
}
