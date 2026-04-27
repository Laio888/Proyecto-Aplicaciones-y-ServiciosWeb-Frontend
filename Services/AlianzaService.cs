using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class AlianzaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AlianzaService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Alianza>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<Alianza>>("Alianza") ?? new();
        }

        public async Task Create(Alianza alianza)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.PostAsJsonAsync("Alianza", alianza);
        }

        public async Task Delete(int aliado, int departamento, int docente)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.DeleteAsync($"Alianza/{aliado}/{departamento}/{docente}");
        }
    }
}