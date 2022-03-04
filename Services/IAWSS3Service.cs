using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApi.Services
{
  public interface IAWSS3Service
  {
    Task<string> UploadFile(IFormFile formFile);
  }
}
