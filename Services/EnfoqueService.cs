using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class EnfoqueService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public EnfoqueService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<Enfoque>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<Enfoque>>("enfoque")
               ?? new List<Enfoque>();
    }

    public async Task<Enfoque?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<Enfoque>($"enfoque/{id}");
    }

    public async Task Create(Enfoque enfoque)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("enfoque", enfoque);
    }

    public async Task Update(int id, Enfoque enfoque)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"enfoque/{id}", enfoque);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"enfoque/{id}");
    }
}