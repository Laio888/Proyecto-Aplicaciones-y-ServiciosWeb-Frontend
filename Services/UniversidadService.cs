using System.Net.Http.Headers;
using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class UniversidadService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public UniversidadService(IHttpClientFactory factory, AuthFrontendService auth)
    {
        _http = factory.CreateClient("API");
        _auth = auth;
    }

    private async Task<HttpRequestMessage> CrearRequestAsync(HttpMethod method, string url)
    {
        var request = new HttpRequestMessage(method, url);

        var token = await _auth.GetTokenAsync();



        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        return request;
    }

    public async Task<List<Universidad>> GetAll()
    {
        var request = await CrearRequestAsync(HttpMethod.Get, "universidad");
        var response = await _http.SendAsync(request);

        var contenido = await response.Content.ReadAsStringAsync();


        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error API Universidad: {(int)response.StatusCode} - {contenido}");
        }

        return await response.Content.ReadFromJsonAsync<List<Universidad>>() ?? new();
    }

    public async Task<Universidad?> GetById(int id)
    {
        var request = await CrearRequestAsync(HttpMethod.Get, $"universidad/{id}");
        var response = await _http.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var contenido = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error API Universidad: {(int)response.StatusCode} - {contenido}");
        }

        return await response.Content.ReadFromJsonAsync<Universidad>();
    }

    public async Task Create(Universidad universidad)
    {
        var request = await CrearRequestAsync(HttpMethod.Post, "universidad");
        request.Content = JsonContent.Create(universidad);

        var response = await _http.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var contenido = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error creando Universidad: {(int)response.StatusCode} - {contenido}");
        }
    }

    public async Task Update(int id, Universidad universidad)
    {
        var request = await CrearRequestAsync(HttpMethod.Put, $"universidad/{id}");
        request.Content = JsonContent.Create(universidad);

        var response = await _http.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var contenido = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error actualizando Universidad: {(int)response.StatusCode} - {contenido}");
        }
    }

    public async Task Delete(int id)
    {
        var request = await CrearRequestAsync(HttpMethod.Delete, $"universidad/{id}");
        var response = await _http.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var contenido = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error eliminando Universidad: {(int)response.StatusCode} - {contenido}");
        }
    }
}