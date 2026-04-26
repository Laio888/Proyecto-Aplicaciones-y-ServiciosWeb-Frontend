using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

public class UsuarioService
{
    private readonly HttpClient _http;

    public UsuarioService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("API");
    }

    public async Task<List<UsuarioConRoles>> GetAll()
        => await _http.GetFromJsonAsync<List<UsuarioConRoles>>("usuario") ?? new();

    public async Task<UsuarioConRoles> GetById(int id)
        => await _http.GetFromJsonAsync<UsuarioConRoles>($"usuario/{id}") ?? new();

    public async Task Create(Usuario u, List<int> roles)
        => await _http.PostAsJsonAsync("usuario", new { usuario = u, roles });

    public async Task Update(int id, Usuario u, List<int> roles)
        => await _http.PutAsJsonAsync($"usuario/{id}", new { usuario = u, roles });

    public async Task Delete(int id)
        => await _http.DeleteAsync($"usuario/{id}");
}