using API.Extensions;

namespace API.Entities
{
    // Definimos la clase AppUser.
    // Esta clase representa una entidad (una fila) de la tabla "Users" en la base de datos.
    public class AppUser
    {
        // Esta propiedad representa la clave primaria (Primary Key) de la entidad.
        // Por convención, Entity Framework reconocerá "Id" como la PK de la tabla.
        
        public int Id { get; set; }

        // Esta propiedad representa el nombre de usuario.
        // El modificador 'required' (disponible desde C# 11) indica que esta propiedad debe ser obligatoriamente seteada.
        // Esto ayuda a evitar nulos en tiempo de compilación o ejecución.
        public required string UserName { get; set; }


        public byte[] PasswordHash { get; set; } = [];


        public byte[] PasswordSalt { get; set; } = [];

        public DateOnly DateOfBirth { get; set; }

        public required string KnownAs { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        public required string Gender { get; set; }

        public string? Introduction { get; set; }

        public string? Interests { get; set; }

        public string? LookingFor { get; set; }

        public required string City { get; set; }

        public List<Photo> Photos { get; set; } = [];
    
        public int GetAge()
        {
            // Calcula la edad del usuario a partir de su fecha de nacimiento.
            return DateOfBirth.CalculateAge();
        }
    }
}
