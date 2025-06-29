using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers;

//[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
 
    [HttpGet]

    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        // Obtiene todos los usuarios de la base de datos.
        var users = await userRepository.GetUsersAsync();
        return Ok(users);
    }

    [HttpGet("{username}")]
    
    public async Task<ActionResult<AppUser>> GetUser(string username)
    {
        // Busca un usuario por su ID.
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null) return NotFound();
        return user;
    }

}

