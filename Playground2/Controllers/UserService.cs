using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Playground2.Entity;
using Playground2.Models;
using Playground2.Temp;
using Playground2.Utils;

namespace Playground2.Temp;
[ApiController]
[Route("api/[controller]")]
public class UserService
{
    private readonly SampleDbContext _context; 
    public UserService(SampleDbContext context)
    {
        _context = context;
    }
    [HttpPost("api/account/register")]
    public async Task<ActionResult<TokenResponse>> Register([FromBody]UserRegisterModel2 model)
    {
        bool registrationAllowed = !_context.Users.Any(user => user.Email == model.Email);
        if (!registrationAllowed)
        {
            // TODO: Determine how to handle this case (the idea is to return 409 here or maybe write a
            // custom error handler that will throw "This email is already taken")
            return null; 
        }
        TokenResponse token = new TokenResponse(TokenController.GenerateAccessToken(model.Email));
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

    [HttpPost("api/account/login")]
    public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginCredentials creds)
    {
    // Find user by email in data base and then check if passwords match
    //T result = Array.Find(array, element => element.PropertyName == valueToFind);
    var user = _context.Users.FirstOrDefault(user => user.Email == creds.Email);

    }
}