using System.ComponentModel.DataAnnotations;
using Playground2.Entity;

namespace Playground2.Temp;

public class UserRegisterModel
{
    [MinLength(1)]
    [MaxLength(1000)]
    public string FullName { get; set; }
    [MinLength(6)]
    public string Password { get; set; }
    [MinLength(1)]
    public string Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string? PhoneNumber { get; set; }
}