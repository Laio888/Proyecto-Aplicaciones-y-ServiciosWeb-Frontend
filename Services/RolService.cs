using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class RolService
{
    private readonly HttpClient _http;

    public RolService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<Rol>> GetAll()
        => await _http.GetFromJsonAsync<List<Rol>>("rol") ?? new();

    public async Task<Rol> GetById(int id)
        => await _http.GetFromJsonAsync<Rol>($"rol/{id}") ?? new();

    public async Task Create(Rol r)
        => await _http.PostAsJsonAsync("rol", r);

    public async Task Update(int id, Rol r)
        => await _http.PutAsJsonAsync($"rol/{id}", r);

    public async Task Delete(int id)
        => await _http.DeleteAsync($"rol/{id}");
}