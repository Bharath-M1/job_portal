namespace WebApi.Services
{
  public interface IUploadService
  {
    Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
  }
}