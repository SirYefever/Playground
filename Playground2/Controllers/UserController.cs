using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net.Http;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Playground2.Entity;
using Playground2.Models;
using Playground2.Temp;

namespace Playground2.Controllers;
public class UserController
{
    private readonly SampleDbContext _context; 
    public UserController(SampleDbContext context)
    {
        _context = context;
    }
    
    
    [HttpPost("api/account/register")]
    public async Task<ActionResult<TokenResponse>> Register([FromBody]UserRegisterModel2 model)
    {
        bool registrationAllowed = !_context.Users.Any(user => user.Email == model.Email);
        if (!registrationAllowed)
        {
            return null; // TODO: Determine how to handle this case (the idea is to return 409 here)
        }
        TokenResponse token = new TokenResponse(GenerateAccessToken(model.Email));
        User user = Temp.UserConverters.UserRegisterModelToUser(model); 
        
        // TODO: Dedicate weather this is the way to validate property's length
        // Validate fullName length and phoneNumberLength 
        if (user.FullName.Length < 1 || user.PhoneNumber.Length < 1)
            return null; // TODO: Determine how to handle this case (need swagger to return corresponding code)
        
        user.Token = token.Token;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return token;
    }
    
    private string GenerateAccessToken(string email)
    {
        // Create user claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, email),
            // Add additional claims as needed (e.g., roles, etc.)
        };

        // TODO: Figure out where to take issuer and audience from 
        // Create a JWT
        var token = new JwtSecurityToken(
            issuer: "localhost",
            audience: "localhost",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(1440), // Token expiration time
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyqwertyqwertyqwertyqwertyqwertyqwertyqwertyqwerty")),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}