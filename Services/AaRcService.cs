using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class AaRcService
    {
        private readonly HttpClient _http;

        public AaRcService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<List<AaRc>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<AaRc>>("AaRc")
                   ?? new List<AaRc>();
        }

        public async Task<AaRc?> GetById(int activAcademicasIdcurso, int registroCalificadoCodigo)
        {
            return await _http.GetFromJsonAsync<AaRc>(
                $"AaRc/{activAcademicasIdcurso}/{registroCalificadoCodigo}");
        }

        public async Task<bool> Create(AaRc item)
        {
            var response = await _http.PostAsJsonAsync("AaRc", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int activAcademicasIdcurso, int registroCalificadoCodigo, AaRc item)
        {
            var response = await _http.PutAsJsonAsync(
                $"AaRc/{activAcademicasIdcurso}/{registroCalificadoCodigo}", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int activAcademicasIdcurso, int registroCalificadoCodigo)
        {
            var response = await _http.DeleteAsync(
                $"AaRc/{activAcademicasIdcurso}/{registroCalificadoCodigo}");
            return response.IsSuccessStatusCode;
        }
    }
}