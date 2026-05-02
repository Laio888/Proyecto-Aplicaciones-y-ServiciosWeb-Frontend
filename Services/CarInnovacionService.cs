using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class CarInnovacionService
{
    private readonly HttpClient _http;
    private readonly AuthFrontendService _auth;

    public CarInnovacionService(IHttpClientFactory factory, AuthFrontendService auth)
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

    public async Task<List<CarInnovacion>> GetAll()
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<List<CarInnovacion>>("CarInnovacion")
               ?? new List<CarInnovacion>();
    }

    public async Task<CarInnovacion?> GetById(int id)
    {
        await AgregarTokenAsync();

        return await _http.GetFromJsonAsync<CarInnovacion>($"CarInnovacion/{id}");
    }

    public async Task Create(CarInnovacion carInnovacion)
    {
        await AgregarTokenAsync();

        await _http.PostAsJsonAsync("CarInnovacion", carInnovacion);
    }

    public async Task Update(int id, CarInnovacion carInnovacion)
    {
        await AgregarTokenAsync();

        await _http.PutAsJsonAsync($"CarInnovacion/{id}", carInnovacion);
    }

    public async Task Delete(int id)
    {
        await AgregarTokenAsync();

        await _http.DeleteAsync($"CarInnovacion/{id}");
    }
}