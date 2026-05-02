using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class PracticaEstrategiaService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public PracticaEstrategiaService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<PracticaEstrategia>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<PracticaEstrategia>>("PracticaEstrategia")
               ?? new List<PracticaEstrategia>();
    }

    public async Task<PracticaEstrategia?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<PracticaEstrategia>($"PracticaEstrategia/{id}");
    }

    public async Task Create(PracticaEstrategia practicaEstrategia)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("PracticaEstrategia", practicaEstrategia);
    }

    public async Task Update(int id, PracticaEstrategia practicaEstrategia)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"PracticaEstrategia/{id}", practicaEstrategia);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"PracticaEstrategia/{id}");
    }
}