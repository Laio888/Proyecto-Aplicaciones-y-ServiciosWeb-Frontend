using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class PasantiaService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public PasantiaService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<Pasantia>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<Pasantia>>("pasantia") ?? new();
    }

    public async Task<Pasantia?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<Pasantia>($"pasantia/{id}");
    }

    public async Task Create(Pasantia obj)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("pasantia", obj);
    }

    public async Task Update(int id, Pasantia obj)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"pasantia/{id}", obj);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"pasantia/{id}");
    }
}