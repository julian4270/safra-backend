using Microsoft.AspNetCore.Mvc;
using Safrasas.Api.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Safrasas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthClientsController : ControllerBase
    {
        private readonly string secretKey;

        public AuthClientsController(IConfiguration config) {
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
        }

        [HttpPost]
        [Route("GenerateJWTToken")]
        public IActionResult Validar([FromBody] Usuario request) {

            if (request.email == "guitarrajulian@hotmail.com" && request.password == "123")
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokencreado = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });

            }
            else {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "Validate your email and password foy generate JWT Token" });
            }   
        }
    }
}
