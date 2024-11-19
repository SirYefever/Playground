using System.ComponentModel.DataAnnotations;

namespace Playground2.Temp;

public class TokenResponse
{
    public TokenResponse(string token)
    {
        Token = token;
    }

    [MinLength(1)]
    public string Token { get; set; }
}