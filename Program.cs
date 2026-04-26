using Microsoft.AspNetCore.Components.Authorization;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Components;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services.Auth;
using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services.Api;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// ======================
// COMPONENTES
// ======================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ======================
// LOCAL STORAGE
// ======================
builder.Services.AddBlazoredLocalStorage();

// ======================
// AUTH CORE (SIN CICLOS)
// ======================
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
    sp.GetRequiredService<CustomAuthStateProvider>());

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthMessageHandler>();

builder.Services.AddAuthorizationCore();

// ======================
// HTTP CLIENT
// ======================
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:5000/api/");
})
.AddHttpMessageHandler<AuthMessageHandler>();

// ======================
// SERVICIOS (TEMPORAL OK)
// ======================

// ENTREGABLE 1
builder.Services.AddScoped<UniversidadService>();
builder.Services.AddScoped<EnfoqueService>();
builder.Services.AddScoped<AspectoNormativoService>();
builder.Services.AddScoped<CarInnovacionService>();
builder.Services.AddScoped<PracticaEstrategiaService>();

// ENTREGABLE 2
builder.Services.AddScoped<FacultadService>();
builder.Services.AddScoped<ProgramaService>();
builder.Services.AddScoped<PasantiaService>();
builder.Services.AddScoped<PremioService>();
builder.Services.AddScoped<AreaConocimientoService>();

// ENTREGABLE 3
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ApiService>();

// RELACIONES N:M
builder.Services.AddScoped<ProgramaAcService>();
builder.Services.AddScoped<ProgramaCiService>();
builder.Services.AddScoped<ProgramaPeService>();

// ======================
// BUILD
// ======================
var app = builder.Build();

// ======================
// MIDDLEWARE
// ======================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

// ======================
// RENDER
// ======================
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();