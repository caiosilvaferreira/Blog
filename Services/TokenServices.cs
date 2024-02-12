using Blog.Extensions;
using Blog.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Services
{
    public class TokenServices             // finalidade dessa classe é para gerar um Token
    {

        public string GenerateToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
            var claims = user.GetClaims();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
               Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),    // limite de oito horas de token, pois ele pode ser descoberto por hacker e usado tbm caso ele fosse permanente
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
}
