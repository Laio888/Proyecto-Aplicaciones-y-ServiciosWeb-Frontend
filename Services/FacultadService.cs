using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class FacultadService
{
    private readonly HttpClient _http;

    public FacultadService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<Facultad>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<Facultad>>("facultad");
    }

    public async Task<Facultad> GetById(int id)
    {
        return await _http.GetFromJsonAsync<Facultad>($"facultad/{id}");
    }

    public async Task Create(Facultad facultad)
    {
        await _http.PostAsJsonAsync("facultad", facultad);
    }

    public async Task Update(int id, Facultad facultad)
    {
        await _http.PutAsJsonAsync($"facultad/{id}", facultad);
    }

    public async Task Delete(int id)
    {
        await _http.DeleteAsync($"facultad/{id}");
    }
}