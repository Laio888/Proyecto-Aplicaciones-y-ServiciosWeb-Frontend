using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class DocenteDepartamentoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AuthFrontendService _auth;

        public DocenteDepartamentoService(IHttpClientFactory httpClientFactory, AuthFrontendService auth)
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

        public async Task<List<DocenteDepartamento>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            return await client.GetFromJsonAsync<List<DocenteDepartamento>>("DocenteDepartamento") ?? new();
        }

        public async Task Create(DocenteDepartamento item)
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            await client.PostAsJsonAsync("DocenteDepartamento", item);
        }

        public async Task Delete(int docente, int departamento)
        {
            var client = _httpClientFactory.CreateClient("API");
            await AgregarTokenAsync(client);

            await client.DeleteAsync($"DocenteDepartamento/{docente}/{departamento}");
        }
    }
}