using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Playground2.Entity;
using Playground2.Models;

namespace Playground2.Temp;

public class UserService
{
    private readonly SampleDbContext _context;

    public UserService(SampleDbContext context)
    {
        _context = context;
    }

    [HttpPost("api/account/register")]
    public async Task<ActionResult<TokenResponse>> AddUser(UserRegisterModel userRegModel)
    {
        _context.Users.Add(userRegModel);
        await _context.SaveChangesAsync();
        return token;
    }
    
    [HttpPost("api/account/login")]
    public Task<ActionResult<TokenResponse>> Login([FromBody] LoginCredentials creds)
    {
        bool itemExists = list.Any(item => item.PropertyName == desiredValue);

        // Check user credentials (in a real application, you'd authenticate against a database)
        if (_context.Users.Any(user => (user.Email == creds.Email && user.Password == creds.Password)))
        {
            var tokenResponse = new TokenResponse();
            tokenResponse.Token = new JwtSecurityTokenHandler().WriteToken(GenerateAccessToken(creds.Email));
            return tokenResponse;
        }
        // unauthorized user
        return Unauthorized("Invalid credentials");
    }
    
    // TODO Decide where this function is supposed to be.
    private JwtSecurityToken GenerateAccessToken(string userName)
    {
        // Create user claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            // Add additional claims as needed (e.g., roles, etc.)
        };

        // Create a JWT
        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(1), // Token expiration time
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"])),
                SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
    
}