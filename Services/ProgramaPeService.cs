using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class ProgramaPeService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public ProgramaPeService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<ProgramaPe>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<ProgramaPe>>("programape")
               ?? new List<ProgramaPe>();
    }

    public async Task<ProgramaPe?> GetById(int programaId, int practicaEstrategiaId)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<ProgramaPe>(
            $"programape/{programaId}/{practicaEstrategiaId}");
    }

    public async Task Create(ProgramaPe p)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("programape", p);
    }

    public async Task Delete(int programaId, int practicaEstrategiaId)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"programape/{programaId}/{practicaEstrategiaId}");
    }
}