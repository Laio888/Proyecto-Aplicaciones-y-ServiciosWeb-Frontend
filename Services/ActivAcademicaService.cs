using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class ActivAcademicaService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public ActivAcademicaService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<ActivAcademica>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<ActivAcademica>>("activAcademica")
               ?? new List<ActivAcademica>();
    }

    public async Task<ActivAcademica?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<ActivAcademica>($"activAcademica/{id}");
    }

    public async Task Create(ActivAcademica activAcademica)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("activAcademica", activAcademica);
    }

    public async Task Update(int id, ActivAcademica activAcademica)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"activAcademica/{id}", activAcademica);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"activAcademica/{id}");
    }
}