using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class PremioService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public PremioService(IHttpClientFactory factory, AuthFrontendService auth)
    {
        _http = factory.CreateClient("API");
        _auth = auth;
    }

    private async Task AgregarTokenAsync()
    {
        var token = await _auth.GetTokenAsync();

        _http.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrWhiteSpace(token))
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<List<Premio>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<Premio>>("premio") ?? new();
    }

    public async Task<Premio?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<Premio>($"premio/{id}");
    }

    public async Task Create(Premio p)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("premio", p);
    }

    public async Task Update(int id, Premio p)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"premio/{id}", p);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"premio/{id}");
    }
}