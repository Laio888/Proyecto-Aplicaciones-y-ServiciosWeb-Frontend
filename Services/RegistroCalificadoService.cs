using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class RegistroCalificadoService
    {
        private readonly HttpClient _http;

        public RegistroCalificadoService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<List<RegistroCalificado>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<RegistroCalificado>>("RegistroCalificado")
                   ?? new List<RegistroCalificado>();
        }

        public async Task<RegistroCalificado?> GetById(int codigo)
        {
            return await _http.GetFromJsonAsync<RegistroCalificado>($"RegistroCalificado/{codigo}");
        }

        // CREATE
        public async Task<bool> Create(RegistroCalificado item)
        {
            var response = await _http.PostAsJsonAsync("RegistroCalificado", item);
            return response.IsSuccessStatusCode;
        }

        // UPDATE
        public async Task<bool> Update(int codigo, RegistroCalificado item)
        {
            var response = await _http.PutAsJsonAsync($"RegistroCalificado/{codigo}", item);
            return response.IsSuccessStatusCode;
        }

        //  DELETE
        public async Task<bool> Delete(int codigo)
        {
            var response = await _http.DeleteAsync($"RegistroCalificado/{codigo}");
            return response.IsSuccessStatusCode;
        }
    }
}