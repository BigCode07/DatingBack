using API.Data; // Importa el namespace donde está definido el contexto de base de datos.
using API.Extensions; // Importa métodos de extensión personalizados, probablemente para servicios.
using API.Interfaces; // Importa interfaces utilizadas en los servicios.
using API.Middleware; // Importa middlewares personalizados, como manejo de excepciones.
using API.Services; // Importa servicios como token o usuario.
using Microsoft.AspNetCore.Authentication.JwtBearer; // Para autenticar usando JWT.
using Microsoft.EntityFrameworkCore; // Para usar Entity Framework Core.
using Microsoft.IdentityModel.Tokens; // Para configurar validación de tokens JWT.
using System.Text; // Para operaciones con cadenas y codificación.

var builder = WebApplication.CreateBuilder(args); // Crea el builder de la aplicación web (carga configuración, servicios, etc.).

builder.Services.AddApplicationServices(builder.Configuration); // Agrega servicios personalizados definidos en ApplicationServices (como repositorios, token service, etc.).
builder.Services.AddIdentityServices(builder.Configuration); // Agrega e inicializa servicios relacionados a la autenticación y autorización.

var app = builder.Build(); // Construye la aplicación a partir de la configuración.


// Middleware personalizado para manejo de excepciones globales.
app.UseMiddleware<ExceptionMiddleware>();

// Habilita CORS para permitir solicitudes desde Angular local en desarrollo.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost.4200"));

app.UseAuthentication(); // Activa el middleware de autenticación (verifica tokens JWT).

app.UseAuthorization(); // Activa el middleware de autorización (verifica políticas o roles).

app.MapControllers(); // Mapea los controladores para responder a las rutas HTTP.

// Crea un scope para usar los servicios registrados con inyección de dependencias.
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var contet = services.GetRequiredService<DataContext>(); // Obtiene el contexto de base de datos.
    await contet.Database.MigrateAsync(); // Aplica cualquier migración pendiente a la base de datos.
    await Seed.SeedUsers(contet); // Carga datos iniciales (por ejemplo, usuarios de prueba).
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>(); // Obtiene el servicio de logging.
    logger.LogError(ex, "An error occurred during migration"); // Registra el error durante la migración.
}

app.Run(); // Inicia la aplicación y empieza a escuchar solicitudes HTTP.
