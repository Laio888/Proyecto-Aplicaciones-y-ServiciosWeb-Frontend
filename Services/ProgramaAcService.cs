using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class ProgramaAcService
{
    private readonly HttpClient _http;

    public ProgramaAcService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<ProgramaAc>> GetAll()
        => await _http.GetFromJsonAsync<List<ProgramaAc>>("programaac");

    public async Task<List<ProgramaAc>> GetByPrograma(int programaId)
        => await _http.GetFromJsonAsync<List<ProgramaAc>>($"programaac/programa/{programaId}");

    public async Task<ProgramaAc> GetById(int programaId, int areaConocimientoId)
        => await _http.GetFromJsonAsync<ProgramaAc>($"programaac/{programaId}/{areaConocimientoId}");

    public async Task Create(ProgramaAc p)
        => await _http.PostAsJsonAsync("programaac", p);

    public async Task Delete(int programaId, int areaConocimientoId)
        => await _http.DeleteAsync($"programaac/{programaId}/{areaConocimientoId}");
}