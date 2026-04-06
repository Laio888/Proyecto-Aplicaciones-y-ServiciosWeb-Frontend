using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class ActivAcademicaService
{
    private readonly HttpClient _http;

    public ActivAcademicaService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<ActivAcademica>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<ActivAcademica>>("activAcademica");
    }

    public async Task<ActivAcademica> GetById(int id)
    {
        return await _http.GetFromJsonAsync<ActivAcademica>($"activAcademica/{id}");
    }

    public async Task Create(ActivAcademica activAcademica)
    {
        await _http.PostAsJsonAsync("activAcademica", activAcademica);
    }

    public async Task Update(int id, ActivAcademica activAcademica)
    {
        await _http.PutAsJsonAsync($"activAcademica/{id}", activAcademica);
    }

    public async Task Delete(int id)
    {
        await _http.DeleteAsync($"activAcademica/{id}");
    }
}