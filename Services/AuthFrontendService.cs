using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class AuthFrontendService
{
    private readonly HttpClient _http;
    private readonly ProtectedSessionStorage _sessionStorage;

    private string? _token;

    public AuthFrontendService(
        IHttpClientFactory factory,
        ProtectedSessionStorage sessionStorage)
    {
        _http = factory.CreateClient("AuthAPI");
        _sessionStorage = sessionStorage;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var response = await _http.PostAsJsonAsync("Auth/login", new
        {
            email,
            password
        });

        if (!response.IsSuccessStatusCode)
            return false;

        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

        if (loginResponse == null || string.IsNullOrWhiteSpace(loginResponse.Token))
            return false;

        _token = loginResponse.Token;

        await _sessionStorage.SetAsync("authToken", loginResponse.Token);

        return true;
    }

    public async Task<string?> GetTokenAsync()
    {
        if (!string.IsNullOrWhiteSpace(_token))
            return _token;

        try
        {
            var result = await _sessionStorage.GetAsync<string>("authToken");

            if (result.Success && !string.IsNullOrWhiteSpace(result.Value))
            {
                _token = result.Value;
                return _token;
            }
        }
        catch
        {
            return null;
        }

        return null;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await GetTokenAsync();
        return !string.IsNullOrWhiteSpace(token);
    }

    public async Task LogoutAsync()
    {
        _token = null;
        await _sessionStorage.DeleteAsync("authToken");
    }

    public async Task<bool> RegisterAsync(string nombre, string email, string password)
    {
        var response = await _http.PostAsJsonAsync("Auth/registro", new
        {
            nombre,
            email,
            password
        });

        return response.IsSuccessStatusCode;
    }
    public async Task<string?> GetRoleAsync()
    {
        var token = await GetTokenAsync();

        if (string.IsNullOrWhiteSpace(token))
            return null;

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var roleClaim = jwtToken.Claims.FirstOrDefault(c =>
            c.Type == ClaimTypes.Role ||
            c.Type == "role" ||
            c.Type == "roles" ||
            c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

        return roleClaim?.Value;
    }

    public async Task<bool> IsAdminAsync()
    {
        var role = await GetRoleAsync();

        return string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
    }
}