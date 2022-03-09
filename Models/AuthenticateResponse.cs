namespace WebApi.Models;

using WebApi.Models;

public class AuthenticateResponse
{
  public int Id { get; set; }
  public string Username { get; set; }
  public string Token { get; set; }
  public string Type { get; set; }
  public AuthenticateResponse(TblUser user, string token)
  {
    Id = user.Id;
    Username = user.Username;
    Token = token;
    Type = user.Type;
  }
}