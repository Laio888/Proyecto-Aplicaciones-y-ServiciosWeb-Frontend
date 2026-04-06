using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class ProgramaCiService
{
    private readonly HttpClient _http;

    public ProgramaCiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<ProgramaCi>> GetAll()
        => await _http.GetFromJsonAsync<List<ProgramaCi>>("programaci");

    public async Task<List<ProgramaCi>> GetByPrograma(int programaId)
        => await _http.GetFromJsonAsync<List<ProgramaCi>>($"programaci/programa/{programaId}");

    public async Task<ProgramaCi> GetById(int programaId, int carInnovacionId)
        => await _http.GetFromJsonAsync<ProgramaCi>($"programaci/{programaId}/{carInnovacionId}");

    public async Task Create(ProgramaCi p)
        => await _http.PostAsJsonAsync("programaci", p);

    public async Task Delete(int programaId, int carInnovacionId)
        => await _http.DeleteAsync($"programaci/{programaId}/{carInnovacionId}");
}