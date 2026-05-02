using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class AcreditacionService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public AcreditacionService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<Acreditacion>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<Acreditacion>>("acreditacion")
               ?? new List<Acreditacion>();
    }

    public async Task<Acreditacion?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<Acreditacion>($"acreditacion/{id}");
    }

    public async Task Create(Acreditacion acreditacion)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("acreditacion", acreditacion);
    }

    public async Task Update(int id, Acreditacion acreditacion)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"acreditacion/{id}", acreditacion);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"acreditacion/{id}");
    }
}