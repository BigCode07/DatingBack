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


        public required byte[] PasswordHash { get; set; }


        public byte[] PasswordSalt { get; set; }
    }
}
