using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

public class AuthMessageHandler : DelegatingHandler
{
    private readonly AuthFrontendService _auth;

    public AuthMessageHandler(AuthFrontendService auth)
    {
        _auth = auth;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _auth.GetTokenAsync();

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}