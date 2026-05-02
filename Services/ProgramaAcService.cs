using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class ProgramaAcService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public ProgramaAcService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<ProgramaAc>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<ProgramaAc>>("programaac")
               ?? new List<ProgramaAc>();
    }

    public async Task<List<ProgramaAc>> GetByPrograma(int programaId)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<ProgramaAc>>($"programaac/programa/{programaId}")
               ?? new List<ProgramaAc>();
    }

    public async Task<ProgramaAc?> GetById(int programaId, int areaConocimientoId)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<ProgramaAc>(
            $"programaac/{programaId}/{areaConocimientoId}");
    }

    public async Task Create(ProgramaAc p)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("programaac", p);
    }

    public async Task Delete(int programaId, int areaConocimientoId)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"programaac/{programaId}/{areaConocimientoId}");
    }
}