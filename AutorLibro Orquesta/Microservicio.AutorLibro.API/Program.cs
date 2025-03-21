using AutorLibro.Infrastructure.Extensiones;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Configuraci�n de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AutorLibros API",
        Version = "v1",
        Description = "Microservicio para gesti�n de autores y sus libros"
    });
});

// **** Configuraci�n personalizada (Infraestructura + Application) ****
builder.Services.AddCustomServices(builder.Configuration);

var app = builder.Build();

// Configuraci�n del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutorLibros API V1");
        c.RoutePrefix = string.Empty;  // Acceder en la ra�z
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();