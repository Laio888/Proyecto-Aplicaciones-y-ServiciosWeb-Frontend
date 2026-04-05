using FrontendBlazor_Aplicaciones_y_Servicios_Web.Components;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

var builder = WebApplication.CreateBuilder(args);

// HttpClient apuntando al backend
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/");
});

// Registrar el servicio
builder.Services.AddScoped<AspectoNormativoService>();
builder.Services.AddScoped<CarInnovacionService>();
builder.Services.AddScoped<EnfoqueService>();
builder.Services.AddScoped<PracticaEstrategiaService>();
builder.Services.AddScoped<UniversidadService>();

// Configuración Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();