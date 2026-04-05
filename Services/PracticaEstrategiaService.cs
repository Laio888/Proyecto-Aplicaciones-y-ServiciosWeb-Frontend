using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class PracticaEstrategiaService
{
    private readonly HttpClient _http;

    public PracticaEstrategiaService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<PracticaEstrategia>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<PracticaEstrategia>>("PracticaEstrategia");
    }

    public async Task<PracticaEstrategia> GetById(int id)
    {
        return await _http.GetFromJsonAsync<PracticaEstrategia>($"PracticaEstrategia/{id}");
    }

    public async Task Create(PracticaEstrategia PracticaEstrategia)
    {
        await _http.PostAsJsonAsync("PracticaEstrategia", PracticaEstrategia);
    }

    public async Task Update(int id, PracticaEstrategia PracticaEstrategia)
    {
        await _http.PutAsJsonAsync($"PracticaEstrategia/{id}", PracticaEstrategia);
    }

    public async Task Delete(int id)
    {
        await _http.DeleteAsync($"PracticaEstrategia/{id}");
    }
}