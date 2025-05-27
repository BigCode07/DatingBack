using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        public string CreateToken(AppUser user)
        {
            var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot access tokenKey from appsettings"); // Obtenemos la clave del token desde la configuración (appsettings.json).
            if(tokenKey.Length < 64) throw new Exception("TokenKey must be at least 64 characters long"); // Verificamos que la clave tenga al menos 64 caracteres.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)); // Creamos una clave simétrica a partir de la clave del token.

            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.NameIdentifier, user.UserName) // Agregamos el nombre del usuario como un reclamo (claim).
            };
            
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature); // Creamos las credenciales de firma utilizando la clave simétrica y el algoritmo HMAC SHA-512.

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), // Asignamos los reclamos al token.
                Expires = DateTime.Now.AddDays(7), // Establecemos la fecha de expiración del token a 7 días.
                SigningCredentials = creds // Establecemos las credenciales de firma del token.
            };

            var tokenHandler = new JwtSecurityTokenHandler(); // Creamos un manejador de tokens JWT.
            var token = tokenHandler.CreateToken(tokenDescriptor); // Creamos el token utilizando el descriptor de seguridad.

            return tokenHandler.WriteToken(token); // Devolvemos el token como una cadena.

        }
    }
   
}
