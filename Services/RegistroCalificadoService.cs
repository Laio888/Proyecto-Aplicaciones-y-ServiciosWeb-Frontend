using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class RegistroCalificadoService
    {
        private readonly HttpClient _http;
        private readonly AuthFrontendService _auth;

        public RegistroCalificadoService(IHttpClientFactory factory, AuthFrontendService auth)
        {
            _http = factory.CreateClient("API");
            _auth = auth;
        }

        private async Task AgregarTokenAsync()
        {
            var token = await _auth.GetTokenAsync();

            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrWhiteSpace(token))
            {
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<List<RegistroCalificado>> GetAll()
        {
            await AgregarTokenAsync();

            return await _http.GetFromJsonAsync<List<RegistroCalificado>>("RegistroCalificado")
                   ?? new List<RegistroCalificado>();
        }

        public async Task<RegistroCalificado?> GetById(int codigo)
        {
            await AgregarTokenAsync();

            return await _http.GetFromJsonAsync<RegistroCalificado>($"RegistroCalificado/{codigo}");
        }

        // CREATE
        public async Task<bool> Create(RegistroCalificado item)
        {
            await AgregarTokenAsync();

            var response = await _http.PostAsJsonAsync("RegistroCalificado", item);
            return response.IsSuccessStatusCode;
        }

        // UPDATE
        public async Task<bool> Update(int codigo, RegistroCalificado item)
        {
            await AgregarTokenAsync();

            var response = await _http.PutAsJsonAsync($"RegistroCalificado/{codigo}", item);
            return response.IsSuccessStatusCode;
        }

        // DELETE
        public async Task<bool> Delete(int codigo)
        {
            await AgregarTokenAsync();

            var response = await _http.DeleteAsync($"RegistroCalificado/{codigo}");
            return response.IsSuccessStatusCode;
        }
    }
}