using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class EnfoqueService
{
    private readonly HttpClient _http;

    public EnfoqueService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<Enfoque>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<Enfoque>>("enfoque");
    }

    public async Task<Enfoque> GetById(int id)
    {
        return await _http.GetFromJsonAsync<Enfoque>($"enfoque/{id}");
    }

    public async Task Create(Enfoque enfoque)
    {
        await _http.PostAsJsonAsync("enfoque", enfoque);
    }

    public async Task Update(int id, Enfoque enfoque)
    {
        await _http.PutAsJsonAsync($"enfoque/{id}", enfoque);
    }

    public async Task Delete(int id)
    {
        await _http.DeleteAsync($"enfoque/{id}");
    }
}