using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers;

//[Authorize]
public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
{
 
    [HttpGet]

    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        // Obtiene todos los usuarios de la base de datos.
        var users = await userRepository.GetUsersAsync();
        var usersToReturn = mapper.Map<IEnumerable<MemberDto>>(users);
        return Ok(usersToReturn);
    }

    [HttpGet("{username}")]
    
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        // Busca un usuario por su ID.
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null) return NotFound();
        return mapper.Map<MemberDto>(user);
    }

}

