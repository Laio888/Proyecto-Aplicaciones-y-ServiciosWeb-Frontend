using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class AlianzaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AuthFrontendService _auth;

        public AlianzaService(IHttpClientFactory httpClientFactory, AuthFrontendService auth)
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

        public async Task<List<Alianza>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            return await client.GetFromJsonAsync<List<Alianza>>("Alianza") ?? new();
        }

        public async Task Create(Alianza alianza)
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            await client.PostAsJsonAsync("Alianza", alianza);
        }

        public async Task Delete(int aliado, int departamento, int docente)
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            await client.DeleteAsync($"Alianza/{aliado}/{departamento}/{docente}");
        }
    }
}