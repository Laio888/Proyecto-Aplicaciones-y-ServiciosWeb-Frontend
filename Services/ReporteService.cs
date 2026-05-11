using System.Net.Http.Json;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos.Reportes;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Services
{
    public class ReporteService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReporteService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ProgramaUniversidadReporte>> ProgramasPorUniversidad()
        {
            var client = _httpClientFactory.CreateClient("API");

            return await client.GetFromJsonAsync<List<ProgramaUniversidadReporte>>
            ("Reportes/programas-universidad")
            ?? new();
        }

        public async Task<List<ProgramaAreaReporte>> ProgramasConAreas()
        {
            var client = _httpClientFactory.CreateClient("API");

            return await client.GetFromJsonAsync<List<ProgramaAreaReporte>>
            ("Reportes/programas-areas")
            ?? new();
        }

        public async Task<DashboardResumen> Dashboard()
        {
            var client = _httpClientFactory.CreateClient("API");

            return await client.GetFromJsonAsync<DashboardResumen>
            ("Reportes/dashboard")
            ?? new();
        }
        public async Task<List<ProgramaInnovacionReporte>> ProgramasConInnovacion()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<ProgramaInnovacionReporte>>("Reportes/programas-innovacion") ?? new();
        }

        public async Task<List<ProgramaPracticaReporte>> ProgramasConPracticas()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<ProgramaPracticaReporte>>("Reportes/programas-practicas") ?? new();
        }

        public async Task<List<ProgramaNormativaReporte>> ProgramasConNormativa()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<ProgramaNormativaReporte>>("Reportes/programas-normativa") ?? new();
        }

        public async Task<List<RegistroCalificadoReporte>> RegistrosCalificados()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<RegistroCalificadoReporte>>("Reportes/registros-calificados") ?? new();
        }

        public async Task<List<ActividadRegistroReporte>> ActividadesConRegistro()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<ActividadRegistroReporte>>("Reportes/actividades-registro") ?? new();
        }

        public async Task<List<EnfoqueRegistroReporte>> EnfoquesConRegistro()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<EnfoqueRegistroReporte>>("Reportes/enfoques-registro") ?? new();
        }

        public async Task<List<AlianzaProgramaReporte>> AlianzasPorPrograma()
        {
            var client = _httpClientFactory.CreateClient("API");
            return await client.GetFromJsonAsync<List<AlianzaProgramaReporte>>("Reportes/alianzas-programa") ?? new();
        }
    }
}