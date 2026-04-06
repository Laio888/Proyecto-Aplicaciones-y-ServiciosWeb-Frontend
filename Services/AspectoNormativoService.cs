using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class AspectoNormativoService
{
    private readonly HttpClient _http;

    public AspectoNormativoService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<AspectoNormativo>> GetAll()
    {
        return await _http.GetFromJsonAsync<List<AspectoNormativo>>("AspectoNormativo");
    }

    public async Task<AspectoNormativo> GetById(int id)
    {
        return await _http.GetFromJsonAsync<AspectoNormativo>($"AspectoNormativo/{id}");
    }

    public async Task Create(AspectoNormativo AspectoNormativo)
    {
        await _http.PostAsJsonAsync("AspectoNormativo", AspectoNormativo);
    }

    public async Task Update(int id, AspectoNormativo AspectoNormativo)
    {
        await _http.PutAsJsonAsync($"AspectoNormativo/{id}", AspectoNormativo);
    }

    public async Task Delete(int id)
    {
        await _http.DeleteAsync($"AspectoNormativo/{id}");
    }
}