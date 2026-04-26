using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly AuthService _authService;

    public CustomAuthStateProvider(AuthService authService)
    {
        _authService = authService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // 🔥 CLAVE: evitar crash en prerender
        string? token = null;

        try
        {
            token = await _authService.GetTokenAsync();
        }
        catch
        {
            return Anonymous();
        }

        if (string.IsNullOrWhiteSpace(token))
            return Anonymous();

        var jwt = TryReadJwt(token);

        if (jwt is null || IsExpired(jwt))
            return Anonymous();

        return new AuthenticationState(BuildUser(jwt));
    }

    public void NotifyAuthChanged()
        => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

    // =========================
    // HELPERS
    // =========================

    private JwtSecurityToken? TryReadJwt(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();

            if (!handler.CanReadToken(token))
                return null;

            return handler.ReadJwtToken(token);
        }
        catch
        {
            return null;
        }
    }

    private bool IsExpired(JwtSecurityToken jwt)
    {
        var exp = jwt.Claims.FirstOrDefault(c => c.Type == "exp");

        if (exp is null)
            return false;

        return long.TryParse(exp.Value, out var seconds)
            && DateTimeOffset.FromUnixTimeSeconds(seconds) < DateTimeOffset.UtcNow;
    }

    private ClaimsPrincipal BuildUser(JwtSecurityToken jwt)
    {
        var identity = new ClaimsIdentity(jwt.Claims, "jwt");

        return new ClaimsPrincipal(identity);
    }

    private AuthenticationState Anonymous()
    {
        return new AuthenticationState(
            new ClaimsPrincipal(new ClaimsIdentity()));
    }
}