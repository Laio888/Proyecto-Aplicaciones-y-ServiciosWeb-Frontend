using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class ProgramaService
{
    private readonly HttpClient _http;

    public ProgramaService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<Programa>> GetAll()
        => await _http.GetFromJsonAsync<List<Programa>>("programa");

    public async Task<Programa> GetById(int id)
        => await _http.GetFromJsonAsync<Programa>($"programa/{id}");

    public async Task Create(Programa p)
        => await _http.PostAsJsonAsync("programa", p);

    public async Task Update(int id, Programa p)
        => await _http.PutAsJsonAsync($"programa/{id}", p);

    public async Task Delete(int id)
        => await _http.DeleteAsync($"programa/{id}");
}