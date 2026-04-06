using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class PasantiaService
{
    private readonly HttpClient _http;

    public PasantiaService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<Pasantia>> GetAll()
        => await _http.GetFromJsonAsync<List<Pasantia>>("pasantia") ?? new();

    public async Task<Pasantia?> GetById(int id)
        => await _http.GetFromJsonAsync<Pasantia>($"pasantia/{id}");

    public async Task Create(Pasantia obj)
        => await _http.PostAsJsonAsync("pasantia", obj);

    public async Task Update(int id, Pasantia obj)
        => await _http.PutAsJsonAsync($"pasantia/{id}", obj);

    public async Task Delete(int id)
        => await _http.DeleteAsync($"pasantia/{id}");
}