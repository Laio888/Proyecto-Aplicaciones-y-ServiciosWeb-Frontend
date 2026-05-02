using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class AreaConocimientoService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public AreaConocimientoService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<AreaConocimiento>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<AreaConocimiento>>("areaconocimiento")
               ?? new List<AreaConocimiento>();
    }

    public async Task<AreaConocimiento?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<AreaConocimiento>($"areaconocimiento/{id}");
    }

    public async Task Create(AreaConocimiento a)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("areaconocimiento", a);
    }

    public async Task Update(int id, AreaConocimiento a)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"areaconocimiento/{id}", a);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"areaconocimiento/{id}");
    }
}