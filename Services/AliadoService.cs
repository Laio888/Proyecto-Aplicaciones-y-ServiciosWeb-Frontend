using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class AliadoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AuthFrontendService _auth;

        public AliadoService(IHttpClientFactory httpClientFactory, AuthFrontendService auth)
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

        public async Task<List<Aliado>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            return await client.GetFromJsonAsync<List<Aliado>>("Aliado") ?? new();
        }

        public async Task<Aliado?> GetById(int nit)
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            return await client.GetFromJsonAsync<Aliado>($"Aliado/{nit}");
        }

        public async Task Create(Aliado aliado)
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            await client.PostAsJsonAsync("Aliado", aliado);
        }

        public async Task Update(int nit, Aliado aliado)
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            await client.PutAsJsonAsync($"Aliado/{nit}", aliado);
        }

        public async Task Delete(int nit)
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            await client.DeleteAsync($"Aliado/{nit}");
        }
    }
}