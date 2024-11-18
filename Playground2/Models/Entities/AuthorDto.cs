using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Playground2.Entity;

public class AuthorDto
{
   [Required]
   [MinLength(1)]
   public string FullName { get; set; }
   public string BirthDate { get; set; }
   [Required]
   public Gender Gender { get; set; }
   public int Posts { get; set; }
   public int Likes { get; set; }
   public string Created { get; set; }
}