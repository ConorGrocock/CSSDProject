using api.Models;

namespace api.Services.Interfaces;
public interface IEmailService
{
    public void Send(EmailItem emailItem);
}