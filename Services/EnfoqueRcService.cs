using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class EnfoqueRcService
    {
        private readonly HttpClient _http;

        public EnfoqueRcService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<List<EnfoqueRc>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<EnfoqueRc>>("EnfoqueRc")
                   ?? new List<EnfoqueRc>();
        }

        public async Task<EnfoqueRc?> GetById(int enfoque, int registroCalificado)
        {
            return await _http.GetFromJsonAsync<EnfoqueRc>($"EnfoqueRc/{enfoque}/{registroCalificado}");
        }

        public async Task<bool> Create(EnfoqueRc item)
        {
            var response = await _http.PostAsJsonAsync("EnfoqueRc", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int enfoque, int registroCalificado)
        {
            var response = await _http.DeleteAsync($"EnfoqueRc/{enfoque}/{registroCalificado}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int enfoqueOriginal, int registroOriginal, EnfoqueRc item)
        {
            var response = await _http.PutAsJsonAsync(
                $"EnfoqueRc/{enfoqueOriginal}/{registroOriginal}", item);

            return response.IsSuccessStatusCode;
        }
    }
}