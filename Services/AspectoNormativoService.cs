using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using System.Net.Http.Json;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class AspectoNormativoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AspectoNormativoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<AspectoNormativo>> GetAll()
        {
            var client = _httpClientFactory.CreateClient("API");

            return await client.GetFromJsonAsync<List<AspectoNormativo>>("AspectoNormativo")
                   ?? new List<AspectoNormativo>();
        }

        public async Task<bool> Create(AspectoNormativo aspecto)
        {
            var client = _httpClientFactory.CreateClient("API");

            var response = await client.PostAsJsonAsync("AspectoNormativo", aspecto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, AspectoNormativo aspecto)
        {
            var client = _httpClientFactory.CreateClient("API");

            var response = await client.PutAsJsonAsync($"AspectoNormativo/{id}", aspecto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("API");

            var response = await client.DeleteAsync($"AspectoNormativo/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}