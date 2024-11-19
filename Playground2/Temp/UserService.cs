using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Playground2.Entity;
using Playground2.Models;
using Playground2.Temp;

namespace Playground2.Temp;

public class UserService
{
    private readonly SampleDbContext _context;

    public UserService(SampleDbContext context)
    {
        _context = context;
    }

    [HttpPost("api/account/register")]
    public async Task<ActionResult<TokenResponse>> Register(UserRegisterModel2 model)
    {
        bool registrationAllowed = !_context.Users.Any(user => user.Email == model.Email);
        if (registrationAllowed)
        {
            User user = Temp.UserConverters.UserRegisterModelToUser(model); 
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            TokenResponse token = new TokenResponse(GenerateAccessToken(model.Email));
            return token;
        }
        return null;// TODO: Determine how to handle this case
    }
    
    private string GenerateAccessToken(string email)
    {
        // Create user claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email),
            // Add additional claims as needed (e.g., roles, etc.)
        };

        // TODO: Figure out where to take issuer and audience from 
        // Create a JWT
        var token = new JwtSecurityToken(
            issuer: "localhost",
            audience: "localhost",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(1440), // Token expiration time
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey")),
                SecurityAlgorithms.HmacSha256)
        );

        return token.ToString();
    }
    
}