using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            // Verifica si ya hay usuarios en la base de datos. Si hay, termina la ejecución del método.
            if (await context.Users.AnyAsync()) return;

            // Lee el contenido del archivo JSON que contiene los usuarios de prueba.
            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            // Define opciones para deserialización: no distingue entre mayúsculas y minúsculas en los nombres de propiedades.
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // Convierte el JSON leído en una lista de objetos AppUser.
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

            // Si no se pudieron deserializar usuarios, termina la ejecución.
            if (users == null) return;

            // Itera cada usuario deserializado.
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512(); // Crea una nueva instancia de HMAC para generar un hash de la contraseña.

                user.UserName = user.UserName.ToLower(); // Convierte el nombre de usuario a minúsculas.

                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd")); // Genera el hash de la contraseña "Pa$$w0rd".

                user.PasswordSalt = hmac.Key; // Guarda la clave (salt) usada en el hash para su validación futura.

                context.Users.Add(user); // Agrega el usuario al contexto (sin guardar aún en la base de datos).
            }

            await context.SaveChangesAsync(); // Guarda todos los cambios (inserta los usuarios) en la base de datos.
        }

    }
}
