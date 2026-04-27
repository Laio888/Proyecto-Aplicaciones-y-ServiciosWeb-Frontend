using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class AliadoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AliadoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Aliado>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<Aliado>>("Aliado") ?? new();
        }

        public async Task<Aliado?> GetById(int nit)
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<Aliado>($"Aliado/{nit}");
        }

        public async Task Create(Aliado aliado)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.PostAsJsonAsync("Aliado", aliado);
        }

        public async Task Update(int nit, Aliado aliado)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.PutAsJsonAsync($"Aliado/{nit}", aliado);
        }

        public async Task Delete(int nit)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.DeleteAsync($"Aliado/{nit}");
        }
    }
}