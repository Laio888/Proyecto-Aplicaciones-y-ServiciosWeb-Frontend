using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class DocenteDepartamentoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DocenteDepartamentoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<DocenteDepartamento>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<DocenteDepartamento>>("DocenteDepartamento") ?? new();
        }

        public async Task Create(DocenteDepartamento item)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.PostAsJsonAsync("DocenteDepartamento", item);
        }

        public async Task Delete(int docente, int departamento)
        {
            var client = _httpClientFactory.CreateClient("API");
            await client.DeleteAsync($"DocenteDepartamento/{docente}/{departamento}");
        }
    }
}