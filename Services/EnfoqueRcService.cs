using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class EnfoqueRcService
    {
        private readonly HttpClient _http;
        private readonly AuthFrontendService _auth;

        public EnfoqueRcService(IHttpClientFactory factory, AuthFrontendService auth)
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

        public async Task<List<EnfoqueRc>> GetAll()
        {
            await AgregarTokenAsync();

            return await _http.GetFromJsonAsync<List<EnfoqueRc>>("EnfoqueRc")
                   ?? new List<EnfoqueRc>();
        }

        public async Task<EnfoqueRc?> GetById(int enfoque, int registroCalificado)
        {
            await AgregarTokenAsync();

            return await _http.GetFromJsonAsync<EnfoqueRc>(
                $"EnfoqueRc/{enfoque}/{registroCalificado}");
        }

        public async Task<bool> Create(EnfoqueRc item)
        {
            await AgregarTokenAsync();

            var response = await _http.PostAsJsonAsync("EnfoqueRc", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int enfoque, int registroCalificado)
        {
            await AgregarTokenAsync();

            var response = await _http.DeleteAsync(
                $"EnfoqueRc/{enfoque}/{registroCalificado}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int enfoqueOriginal, int registroOriginal, EnfoqueRc item)
        {
            await AgregarTokenAsync();

            var response = await _http.PutAsJsonAsync(
                $"EnfoqueRc/{enfoqueOriginal}/{registroOriginal}", item);

            return response.IsSuccessStatusCode;
        }
    }
}