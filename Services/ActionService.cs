using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Services;

namespace WebApi
{
  public class ValidateModelAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        context.Result = new ValidationFailedResult(context.ModelState);
      }
    }
  }
}