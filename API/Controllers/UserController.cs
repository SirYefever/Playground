using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UserController
{
    [HttpPost("api/account/register")]
    public async Task<ActionResult<TokenResponse>> Register([FromBody]UserRegisterModel2 model)
    {
        private readonly IUserService _userService;
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
        var user = _context.Users.FirstOrDefault(user => user.Email == creds.Email);
        if (user.Password != creds.Password)
        {
            return null; //TODO: Dedicate how to handle this case
        }
        TokenResponse token = new TokenResponse(user.Token);
        return token;
    }
}