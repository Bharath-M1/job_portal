using WebApi.Models;

namespace WebApi.Services
{
  public interface IMailService
  {
    public Task SendEmailAsync(MailRequest mailrequest);
  }
}