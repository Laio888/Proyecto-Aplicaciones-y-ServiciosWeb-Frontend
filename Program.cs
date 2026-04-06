using System.Net;
using System.Runtime.CompilerServices;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Components;

var builder = WebApplication.CreateBuilder(args);

// 🔹 1. Servicios base
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 🔹 2. HttpClient
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/");
});

// 🔹 3. Tus services (ANTES de Build)
builder.Services.AddScoped<UniversidadService>();
builder.Services.AddScoped<EnfoqueService>();
builder.Services.AddScoped<AspectoNormativoService>();
builder.Services.AddScoped<CarInnovacionService>();
builder.Services.AddScoped<PracticaEstrategiaService>();
builder.Services.AddScoped<FacultadService>();
builder.Services.AddScoped<ProgramaService>();
builder.Services.AddScoped<PasantiaService>();

// 🔹 4. Crear app
var app = builder.Build();

// 🔹 5. Configuración (DESPUÉS de Build)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// 🔹 6. Ejecutar
app.Run();