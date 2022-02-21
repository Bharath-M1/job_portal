namespace WebApi.Services;


using WebApi.Models;

public interface IUserService
{
  AuthenticateResponse Authenticate(Login model);

  TblUser GetById(int id);
}
