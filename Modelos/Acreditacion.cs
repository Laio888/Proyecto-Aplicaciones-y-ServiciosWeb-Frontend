using System.ComponentModel.DataAnnotations.Schema;

namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos
{
    public class Acreditacion {
    public int Resolucion { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Calificacion { get; set; } = string.Empty;
    public string FechaInicio { get; set; } = string.Empty;
    public string FechaFin { get; set; } = string.Empty;
    public int Programa { get; set; } 

    
    }
}