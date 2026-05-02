using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class FacultadService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public FacultadService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<Facultad>> GetAll()
    {
        await AgregarTokenAsync();
        return await _http.GetFromJsonAsync<List<Facultad>>("facultad") ?? new();
    }

    public async Task<Facultad?> GetById(int id)
    {
        await AgregarTokenAsync();
        return await _http.GetFromJsonAsync<Facultad>($"facultad/{id}");
    }

    public async Task Create(Facultad facultad)
    {
        await AgregarTokenAsync();
        await _http.PostAsJsonAsync("facultad", facultad);
    }

    public async Task Update(int id, Facultad facultad)
    {
        await AgregarTokenAsync();
        await _http.PutAsJsonAsync($"facultad/{id}", facultad);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();
        await _http.DeleteAsync($"facultad/{id}");
    }
}