using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApi.Models;
namespace WebApi.Models
{
  public class ValidationResultModel
  {
    public string Message { get; }
    public List<ValidationError> Errors { get; }
    public ValidationResultModel(ModelStateDictionary modelState)
    {
      Message = "Validation Failed";
      Errors = modelState.Keys
              .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, 0, x.ErrorMessage)))
              .ToList();
    }
  }
}