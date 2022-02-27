using api.Models;

namespace api.Services.Common.Interfaces;
public interface IEmailService
{
    public void Send(EmailItem emailItem);
}