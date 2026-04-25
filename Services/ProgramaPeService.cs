using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class ProgramaPeService
{
    private readonly HttpClient _http;

    public ProgramaPeService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<ProgramaPe>> GetAll()
        => await _http.GetFromJsonAsync<List<ProgramaPe>>("programape");

    public async Task<ProgramaPe> GetById(int programaId, int practicaEstrategiaId)
        => await _http.GetFromJsonAsync<ProgramaPe>($"programape/{programaId}/{practicaEstrategiaId}");

    public async Task Create(ProgramaPe p)
        => await _http.PostAsJsonAsync("programape", p);

    public async Task Delete(int programaId, int practicaEstrategiaId)
        => await _http.DeleteAsync($"programape/{programaId}/{practicaEstrategiaId}");
}