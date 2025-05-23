using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context) : BaseApiController
{
    // ------------------------------------
    // Forma de trabajo de la API: VERSIONES VIEJAS
    // ------------------------------------
    //private readonly DataContext _context;

    //public UsersController(DataContext context)
    //{
    //    _context = context; 
    //}

    //[HttpGet]

    //public ActionResult<IEnumerable<AppUser>> GetUsers()
    //{
    //    var users = _context.Users.ToList();
    //    return Ok(users);
    //}
    // ------------------------------------

    // Forma de trabajo de la API: VERSIONES NUEVAS
    // ------------------------------------


    // Método HTTP GET que devuelve todos los usuarios de la base de datos.
    // Ruta: GET /api/[controller]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return Ok(users);
    }

    // Método HTTP GET que devuelve todos los usuarios, pero recibe un parámetro 'id' en la URL.
    // Ruta: GET /api/[controller]/{id} 
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();

        return Ok(user);
    }

}

