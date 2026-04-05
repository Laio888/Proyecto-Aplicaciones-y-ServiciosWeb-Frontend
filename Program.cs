using FrontendBlazor_Aplicaciones_y_Servicios_Web.Services;

var builder = WebApplication.CreateBuilder(args);

// HttpClient apuntando al backend
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/");
});

// Registrar el servicio
builder.Services.AddScoped<AspectoNormativoService>();

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
app.UseRouting();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();