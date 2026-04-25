using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class AreaConocimientoService
{
    private readonly HttpClient _http;

    public AreaConocimientoService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<AreaConocimiento>> GetAll()
        => await _http.GetFromJsonAsync<List<AreaConocimiento>>("areaconocimiento");

    public async Task<AreaConocimiento> GetById(int id)
        => await _http.GetFromJsonAsync<AreaConocimiento>($"areaconocimiento/{id}");

    public async Task Create(AreaConocimiento a)
        => await _http.PostAsJsonAsync("areaconocimiento", a);

    public async Task Update(int id, AreaConocimiento a)
        => await _http.PutAsJsonAsync($"areaconocimiento/{id}", a);

    public async Task Delete(int id)
        => await _http.DeleteAsync($"areaconocimiento/{id}");
}