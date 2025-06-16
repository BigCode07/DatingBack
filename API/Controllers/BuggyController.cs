using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController(DataContext context) : BaseApiController
    {
        [Authorize]
        [HttpGet("auth")] // api/buggy/auth
        public ActionResult<string> GetAuth()
        {
            return "secret text";
        }


        [HttpGet("not-found")] // api/buggy/not-found
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = context.Users.Find(-1);

            if(thing == null) return NotFound(); // Si no se encuentra el usuario, devuelve un error 404 (Not Found).

            return thing;
        }

        [HttpGet("server-error")] // api/buggy/server-error
        public ActionResult<AppUser> GetServerError()
        {
            try
            {
                var thing = context.Users.Find(-1) ?? throw new Exception("A bad thing has happened");
                return thing;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message); // Devuelve un error 500 (Internal Server Error) con un mensaje de error.
            }
            
        }

        [HttpGet("bad-request")] // api/buggy/bad-request
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }


    }
}
