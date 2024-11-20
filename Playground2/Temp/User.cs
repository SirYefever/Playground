using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
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
    public string Email { get; set; } //TODO: dedicate how to make it unique
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string? PhoneNumber { get; set; }
}