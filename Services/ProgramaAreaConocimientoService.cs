using System.Net.Http.Json;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class ProgramaAreaConocimientoService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProgramaAreaConocimientoService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task AsignarAsync(int programa, int areaConocimiento)
    {
        var client = _httpClientFactory.CreateClient("API");

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

        await client.DeleteAsync($"ProgramaAc/{programa}/{areaConocimiento}");
    }
}