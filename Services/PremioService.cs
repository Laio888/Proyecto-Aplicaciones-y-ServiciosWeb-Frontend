using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class PremioService
{
    private readonly HttpClient _http;

    public PremioService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<Premio>> GetAll()
        => await _http.GetFromJsonAsync<List<Premio>>("premio");

    public async Task<Premio> GetById(int id)
        => await _http.GetFromJsonAsync<Premio>($"premio/{id}");

    public async Task Create(Premio p)
        => await _http.PostAsJsonAsync("premio", p);

    public async Task Update(int id, Premio p)
        => await _http.PutAsJsonAsync($"premio/{id}", p);

    public async Task Delete(int id)
        => await _http.DeleteAsync($"premio/{id}");
}