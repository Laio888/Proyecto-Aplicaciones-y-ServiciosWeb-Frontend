using System.Net.Http.Json;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services.Auth;

public class AuthService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ProtectedSessionStorage _storage;

    private const string TOKEN_KEY = "authToken";

    public AuthService(
        IHttpClientFactory httpClientFactory,
        ProtectedSessionStorage storage)
    {
        _httpClientFactory = httpClientFactory;
        _storage = storage;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var client = _httpClientFactory.CreateClient("API");

        var response = await client.PostAsJsonAsync("Autenticacion/login", new
        {
            Email = email,
            Contrasena = password
        });

        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

        if (result?.Token is null)
            return false;

        await _storage.SetAsync(TOKEN_KEY, result.Token);

        return true;
    }

    public async Task LogoutAsync()
    {
        await _storage.DeleteAsync(TOKEN_KEY);
    }

    public async Task<string?> GetTokenAsync()
    {
        try
        {
            var result = await _storage.GetAsync<string>(TOKEN_KEY);
            return result.Success ? result.Value : null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<IEnumerable<Claim>> GetClaimsAsync()
    {
        var token = await GetTokenAsync();

        if (string.IsNullOrWhiteSpace(token))
            return [];

        var handler = new JwtSecurityTokenHandler();

        if (!handler.CanReadToken(token))
            return [];

        return handler.ReadJwtToken(token).Claims;
    }

    private class LoginResponse
    {
        public string Token { get; set; } = "";
        public string? Email { get; set; }
        public string? Usuario { get; set; }
        public List<string>? Roles { get; set; }
    }
}