using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebAPIDemo.Managers
{
    public class JWTManager
    {
        public static string GenerateToken()
        {
            string secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
            var symmetricKey = Convert.FromBase64String(secret);
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var cliamIdentiy = new ClaimsIdentity( new List<Claim> {

                new Claim(ClaimTypes.Name, "Chandra")

            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature);
            
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = cliamIdentiy,
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = signingCredentials
            };

            SecurityToken plainToken = jwtTokenHandler.CreateToken(tokenDescriptor);
            string signedAndEncodedToken = jwtTokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;
        }
    }
}