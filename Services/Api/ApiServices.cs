using System.Net.Http.Json;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services.Api;

public class ApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private HttpClient Client =>
        _httpClientFactory.CreateClient("API");

    public async Task<T?> GetAsync<T>(string url)
    {
        var response = await Client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<List<T>?> GetListAsync<T>(string url)
    {
        var response = await Client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<T>>();
    }

    public async Task<T?> PostAsync<T>(string url, object data)
    {
        var response = await Client.PostAsJsonAsync(url, data);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<bool> PostAsync(string url, object data)
    {
        var response = await Client.PostAsJsonAsync(url, data);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> PutAsync(string url, object data)
    {
        var response = await Client.PutAsJsonAsync(url, data);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string url)
    {
        var response = await Client.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
}