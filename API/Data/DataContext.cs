using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

    // Definimos la clase DataContext, que hereda de DbContext.
    // Esto le indica a Entity Framework que esta clase representa una sesión con la base de datos.
    // Se usa para consultar y guardar datos.

    public class DataContext(DbContextOptions options) : DbContext(options)
    {

        // Creamos una propiedad del tipo DbSet<AppUser>.
        // Esto representa una tabla llamada "Users" en la base de datos,
        // y permite realizar operaciones CRUD (crear, leer, actualizar, eliminar) sobre los usuarios.
        public DbSet<AppUser> Users { get; set; }
    }
    
      
        
    
}
// ---------------------------------------------
// 1️) Crear migración inicial:
// dotnet ef migrations add InitialCreate -o Data/Migrations --project ./API
// Descripción:
// - Crea una clase de migración basada en el modelo actual (como AppUser).
// - Guarda los archivos generados en la carpeta Data/Migrations.
// - La opción --project ./API indica en qué proyecto está el DbContext.
//
// 2) Aplicar la migración a la base de datos:
// dotnet ef database update --project ./API
//
//    - Ejecuta las migraciones pendientes y crea/modifica la base de datos.
//    - En este caso, genera el archivo "dating.db" si usás SQLite.
// ---------------------------------------------