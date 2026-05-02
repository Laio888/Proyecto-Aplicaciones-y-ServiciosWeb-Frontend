using System.Net.Http.Headers;
using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class ProgramaService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public ProgramaService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<Programa>> GetAll()
    {
        await AgregarTokenAsync();
        return await _http.GetFromJsonAsync<List<Programa>>("programa") ?? new();
    }

    public async Task<Programa?> GetById(int id)
    {
        await AgregarTokenAsync();
        return await _http.GetFromJsonAsync<Programa>($"programa/{id}");
    }

    public async Task Create(Programa programa)
    {
        await AgregarTokenAsync();
        await _http.PostAsJsonAsync("programa", programa);
    }

    public async Task Update(int id, Programa programa)
    {
        await AgregarTokenAsync();
        await _http.PutAsJsonAsync($"programa/{id}", programa);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();
        await _http.DeleteAsync($"programa/{id}");
    }
}