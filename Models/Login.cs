namespace WebApi.Models;

using System.ComponentModel.DataAnnotations;

public class Login
{
  [Required]
  public string Email { get; set; }

  [Required]
  public string Password { get; set; }
}