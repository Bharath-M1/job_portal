namespace WebApi.Services
{
  public interface IAzureStorage
  {
    Task<string> UploadAsync(Stream fileStream, string fileName, string contentType);
  }
}