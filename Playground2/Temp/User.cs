using System.ComponentModel.DataAnnotations;
using Playground2.Entity;

namespace Playground2.Temp;

public class User
{
    //TODO: Dedicate weather we need attributes here
    public Guid Id { get; set; }
    public string Token { get; set; }
    [MinLength(1)]
    public string FullName { get; set; }
    public string Password { get; set; }
    [MinLength(1)]
    public string Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string? PhoneNumber { get; set; }
}