using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Playground2.Temp;

public class LoginCredentials
{
    [MinLength(1)]
    [EmailAddress]
    public string Email { get; set; }
    [MinLength(1)]
    public string Password { get; set; }
}