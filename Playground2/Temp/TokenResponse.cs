using System.ComponentModel.DataAnnotations;

namespace Playground2.Temp;

public class TokenResponse
{
    [MinLength(1)]
    public string Token { get; set; }
}