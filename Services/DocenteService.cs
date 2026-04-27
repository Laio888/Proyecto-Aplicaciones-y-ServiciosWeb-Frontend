using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class DocenteService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DocenteService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Docente>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<Docente>>("Docente") ?? new();
        }

        public async Task<Docente?> GetById(int cedula)
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<Docente>($"Docente/{cedula}");
        }

        public async Task Create(Docente docente)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.PostAsJsonAsync("Docente", docente);
        }

        public async Task Update(int cedula, Docente docente)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.PutAsJsonAsync($"Docente/{cedula}", docente);
        }

        public async Task Delete(int cedula)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.DeleteAsync($"Docente/{cedula}");
        }
    }
}