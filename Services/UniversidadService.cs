using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class UniversidadService
{
    private readonly HttpClient _http;

    public UniversidadService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<Universidad>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<Universidad>>("universidad") ?? new();
    }

    public async Task<Universidad> GetById(int id)
    {
        return await _http.GetFromJsonAsync<Universidad>($"universidad/{id}");
    }

    public async Task Create(Universidad universidad)
    {
        await _http.PostAsJsonAsync("universidad", universidad);
    }

    public async Task Update(int id, Universidad universidad)
    {
        var response = await _http.PutAsJsonAsync($"universidad/{id}", universidad);
        Console.WriteLine(response.StatusCode);
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"universidad/{id}");
        Console.WriteLine(response.StatusCode);
    }
}