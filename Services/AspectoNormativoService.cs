using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class AspectoNormativoService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public AspectoNormativoService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<AspectoNormativo>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<AspectoNormativo>>("AspectoNormativo")
               ?? new List<AspectoNormativo>();
    }

    public async Task<AspectoNormativo?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<AspectoNormativo>($"AspectoNormativo/{id}");
    }

    public async Task Create(AspectoNormativo aspectoNormativo)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("AspectoNormativo", aspectoNormativo);
    }

    public async Task Update(int id, AspectoNormativo aspectoNormativo)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"AspectoNormativo/{id}", aspectoNormativo);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"AspectoNormativo/{id}");
    }
}