using System.Collections.Generic;
using api.Models;
using api.Services.Common.Interfaces;

namespace Tests.Integration.Services;

public class IntegrationEmailService : IEmailService
{
    public List<EmailItem> EmailItems { get; } = new List<EmailItem>();

    public void Send(EmailItem emailItem) => EmailItems.Add(emailItem);
}