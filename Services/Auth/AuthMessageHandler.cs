using System.Net.Http.Headers;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services.Auth;

public class AuthMessageHandler : DelegatingHandler
{
    private readonly AuthService _authService;

    public AuthMessageHandler(AuthService authService)
    {
        _authService = authService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _authService.GetTokenAsync();

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}