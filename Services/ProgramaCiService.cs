using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class ProgramaCiService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public ProgramaCiService(IHttpClientFactory factory, AuthFrontendService auth)
    {
        _http = factory.CreateClient("API");
        _auth = auth;
    }

    private async Task AgregarTokenAsync()
    {
        var token = await _auth.GetTokenAsync();

        _http.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrWhiteSpace(token))
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<List<ProgramaCi>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<ProgramaCi>>("programaci")
               ?? new List<ProgramaCi>();
    }

    public async Task<List<ProgramaCi>> GetByPrograma(int programaId)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<ProgramaCi>>($"programaci/programa/{programaId}")
               ?? new List<ProgramaCi>();
    }

    public async Task<ProgramaCi?> GetById(int programaId, int carInnovacionId)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<ProgramaCi>(
            $"programaci/{programaId}/{carInnovacionId}");
    }

    public async Task Create(ProgramaCi p)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("programaci", p);
    }

    public async Task Delete(int programaId, int carInnovacionId)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"programaci/{programaId}/{carInnovacionId}");
    }
}