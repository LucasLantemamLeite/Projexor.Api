using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Projexor.Models;

namespace Projexor.Services.Token;

public class JwtServices
{

    public static string GenerateToken(UserAccount user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(JwtSettings.JwtToken);
        var credencial = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim("Active", user.Active.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            ]),

            SigningCredentials = credencial,
            Expires = DateTime.UtcNow.AddHours(8)
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}