namespace WebApi.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApi.Data;
using BC = BCrypt.Net.BCrypt;
using WebApi.Helpers;
using WebApi.Models;

public class UserService : IUserService
{
  private readonly AppSettings _appSettings;
  private readonly jobPortalDbContext _db;
  public UserService(IOptions<AppSettings> appSettings, jobPortalDbContext dbcontext)
  {
    _appSettings = appSettings.Value;
    _db = dbcontext;
  }

  public AuthenticateResponse Authenticate(Login model)
  {
    var user = _db.TblUsers.SingleOrDefault(x => x.Email == model.Email);

    // return null if user not found
    if (user == null || !BC.Verify(model.Password, user.Password)) return null;

    // authentication successful so generate jwt token
    var token = generateJwtToken(user);

    return new AuthenticateResponse(user, token);
  }
  public TblUser GetById(int id)
  {
    return _db.TblUsers.FirstOrDefault(x => x.Id == id);
  }

  private string generateJwtToken(TblUser user)
  {
    // generate token that is valid for 7 days
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[] {
        new Claim("email", user.Email.ToString()),
        new Claim("Id", user.Id.ToString()),
        new Claim("type", user.Type.ToString())
      }),
      Expires = DateTime.UtcNow.AddDays(7),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
}
