namespace FrontendBlazor_Aplicaciones_y_Servicios_Web.Modelos
{
    public class Pasantia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Pais { get; set; } = "";
        public string Empresa { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int Programa { get; set; } // FK 
    }
}