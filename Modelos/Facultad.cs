namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos
{
    public class Facultad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public DateTime FechaFun { get; set; }
        public int Universidad { get; set; } // FK
    }
}