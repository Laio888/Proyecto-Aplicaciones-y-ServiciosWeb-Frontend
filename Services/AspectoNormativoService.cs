using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;
using System.Net.Http.Json;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class AspectoNormativoService
    {
        private readonly HttpClient _http;

        public AspectoNormativoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AspectoNormativo>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<AspectoNormativo>>("AspectoNormativo");
        }

        public async Task<bool> Create(AspectoNormativo aspecto)
        {
            var response = await _http.PostAsJsonAsync("AspectoNormativo", aspecto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int id, AspectoNormativo aspecto)
        {
            var response = await _http.PutAsJsonAsync($"AspectoNormativo/{id}", aspecto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"AspectoNormativo/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}