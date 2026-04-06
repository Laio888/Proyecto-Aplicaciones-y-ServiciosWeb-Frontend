namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos
{
    public class Premio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string Fecha { get; set; } = "";
        public string EntidadOtorgante { get; set; } = "";
        public string Pais { get; set; } = "";
        public int Programa { get; set; }
    }
}