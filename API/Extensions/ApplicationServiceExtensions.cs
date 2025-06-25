using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Add services to the container.
            services.AddControllers();

            // Registrar DataContext con SQLite
            services.AddDbContext<DataContext>(opt =>
            {
                // Obtener la cadena de conexión desde appsettings.json
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();


            services.AddCors();
            services.AddScoped<ITokenService, TokenService>(); // Agregar el servicio de token
            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }
    }
}
