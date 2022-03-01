namespace WebApi.Helpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models;
using Microsoft.AspNetCore.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
  private readonly IList<Role> _roles;

  public AuthorizeAttribute(params Role[] roles)
  {
    _roles = roles ?? new Role[] { };
  }
  public void OnAuthorization(AuthorizationFilterContext context)
  {
    var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
    if (allowAnonymous)
      return;
    var user = (TblUser)context.HttpContext.Items["User"];
    if (user == null || (_roles.Any() && !_roles.Contains(changeToRole(user.Type))))
    {
      context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
    }
  }
  public Role changeToRole(string data)
  {
    string toLower = data.ToString().ToLower();
    Role result;
    switch (toLower)
    {
      case ("seeker"):
        result = Role.Seeker;
        break;
      case ("company"):
        result = Role.Company;
        break;
      case ("admin"):
        result = Role.Admin;
        break;
      default:
        result = Role.Unknown;
        break;
    }

    return result;
  }
}