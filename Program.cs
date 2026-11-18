using ClinicaCitas.Middlewares;
using ClinicaCitas.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar soporte para Controladores
builder.Services.AddControllers();

// 2. Configurar OpenAPI para la documentación
builder.Services.AddOpenApi();

// 3. Inyección de dependencias: Usamos Singleton para que la lista en memoria mantenga sus datos
builder.Services.AddSingleton<ICitaService, CitaService>();

var app = builder.Build();

// 4. Configurar la documentación interactiva con Scalar
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "API Clínica Citas";
    });
}

// 5. Inyectar el Middleware global de manejo de errores
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();