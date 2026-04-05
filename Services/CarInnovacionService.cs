using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class CarInnovacionService
{
    private readonly HttpClient _http;

    public CarInnovacionService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<CarInnovacion>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<CarInnovacion>>("CarInnovacion");
    }

    public async Task<CarInnovacion> GetById(int id)
    {
        return await _http.GetFromJsonAsync<CarInnovacion>($"CarInnovacion/{id}");
    }

    public async Task Create(CarInnovacion CarInnovacion)
    {
        await _http.PostAsJsonAsync("CarInnovacion", CarInnovacion);
    }

    public async Task Update(int id, CarInnovacion CarInnovacion)
    {
        await _http.PutAsJsonAsync($"CarInnovacion/{id}", CarInnovacion);
    }

    public async Task Delete(int id)
    {
        await _http.DeleteAsync($"CarInnovacion/{id}");
    }
}