using System.ComponentModel.DataAnnotations.Schema; // Importa atributos para mapear clases a tablas de base de datos, como [Table]

namespace API.Entities // Define el espacio de nombres donde está ubicada la clase Photo
{
    [Table("Photos")] // Indica que esta clase se mapea a la tabla "Photos" en la base de datos
    public class Photo // Define una clase llamada Photo, que representa una entidad de una foto
    {
        public int Id { get; set; } // Propiedad primaria (por convención) que representa el ID único de la foto

        public required string Url { get; set; } // Propiedad obligatoria que guarda la URL de la imagen (a partir de C# 11 con el modificador `required`)

        public bool IsMain { get; set; } // Indica si esta foto es la principal del usuario (true = sí)

        public string? PublicId { get; set; } // Identificador público (por ejemplo, en un servicio como Cloudinary); es opcional (nullable)

        // Navigation properties

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; } = null!;
    }
}