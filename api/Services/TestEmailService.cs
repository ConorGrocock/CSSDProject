using api.Models;
using api.Services.Common.Interfaces;

namespace api.Services;

public class TestEmailService : IEmailService
{
    private readonly ILogger<TestEmailService> _logger;
    public TestEmailService(ILogger<TestEmailService> logger)
    {
        _logger = logger;
    }
    public void Send(EmailItem emailItem)
    {
        _logger.LogInformation(emailItem.ToString());
    }
}