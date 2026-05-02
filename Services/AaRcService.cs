using System.Net.Http.Json;
using System.Net.Http.Headers;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class AaRcService
    {
        private readonly HttpClient _http;
        private readonly AuthFrontendService _auth;

        public AaRcService(IHttpClientFactory factory, AuthFrontendService auth)
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

        public async Task<List<AaRc>> GetAll()
        {
            await AgregarTokenAsync();

            return await _http.GetFromJsonAsync<List<AaRc>>("AaRc")
                   ?? new List<AaRc>();
        }

        public async Task<AaRc?> GetById(int activAcademicasIdcurso, int registroCalificadoCodigo)
        {
            await AgregarTokenAsync();

            return await _http.GetFromJsonAsync<AaRc>(
                $"AaRc/{activAcademicasIdcurso}/{registroCalificadoCodigo}");
        }

        public async Task<bool> Create(AaRc item)
        {
            await AgregarTokenAsync();

            var response = await _http.PostAsJsonAsync("AaRc", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int activAcademicasIdcurso, int registroCalificadoCodigo, AaRc item)
        {
            await AgregarTokenAsync();

            var response = await _http.PutAsJsonAsync(
                $"AaRc/{activAcademicasIdcurso}/{registroCalificadoCodigo}", item);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int activAcademicasIdcurso, int registroCalificadoCodigo)
        {
            await AgregarTokenAsync();

            var response = await _http.DeleteAsync(
                $"AaRc/{activAcademicasIdcurso}/{registroCalificadoCodigo}");

            return response.IsSuccessStatusCode;
        }
    }
}