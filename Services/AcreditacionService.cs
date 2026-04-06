using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class AcreditacionService
{
    private readonly HttpClient _http;

    public AcreditacionService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<Acreditacion>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<Acreditacion>>("acreditacion");
    }

    public async Task<Acreditacion> GetById(int id)
    {
        return await _http.GetFromJsonAsync<Acreditacion>($"acreditacion/{id}");
    }

    public async Task Create(Acreditacion acreditacion)
    {
        await _http.PostAsJsonAsync("acreditacion", acreditacion);
    }

    public async Task Update(int id, Acreditacion acreditacion)
    {
        await _http.PutAsJsonAsync($"acreditacion/{id}", acreditacion);
    }

    public async Task Delete(int id)
    {
        await _http.DeleteAsync($"acreditacion/{id}");
    }
}