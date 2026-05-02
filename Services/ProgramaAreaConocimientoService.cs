using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class ProgramaAreaConocimientoService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AuthFrontendService _auth;

    public ProgramaAreaConocimientoService(
        IHttpClientFactory httpClientFactory,
        AuthFrontendService auth)
    {
        _httpClientFactory = httpClientFactory;
        _auth = auth;
    }

    private async Task AgregarTokenAsync(HttpClient client)
    {
        var token = await _auth.GetTokenAsync();

        client.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrWhiteSpace(token))
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task AsignarAsync(int programa, int areaConocimiento)
    {
        var client = _httpClientFactory.CreateClient("API");
        await AgregarTokenAsync(client);

        var data = new
        {
            Programa = programa,
            AreaConocimiento = areaConocimiento
        };

        var response = await client.PostAsJsonAsync("ProgramaAc", data);

        response.EnsureSuccessStatusCode();
    }

    public async Task EliminarAsync(int programa, int areaConocimiento)
    {
        var client = _httpClientFactory.CreateClient("API");
        await AgregarTokenAsync(client);

        var response = await client.DeleteAsync($"ProgramaAc/{programa}/{areaConocimiento}");

        response.EnsureSuccessStatusCode();
    }
}