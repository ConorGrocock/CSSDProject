using System;
using System.Net.Http;
using System.Text.Json;
using api.Controllers;
using api.Services.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tests.Integration.Services;

namespace Tests.Integration.Common;

public abstract class BaseTest
{
    protected readonly IServiceProvider _serviceProvider;
    protected readonly HttpClient _client;

    public BaseTest()
    {
        var app = new WebApplicationFactory<Program>().WithWebHostBuilder(Configure);

        _serviceProvider = app.Services;
        _client = app.CreateClient(new WebApplicationFactoryClientOptions
        {
            // default of WebApplicationFactoryClientOptions.BaseAddress
            BaseAddress = new Uri("http://localhost/api/")
        });
    }

    private static void Configure(IWebHostBuilder builder)
    {
        // replace implementation of external services - they cannot be tested against
        builder.ConfigureServices(opt =>
        {
            opt.RemoveAll<IEmailService>();
            opt.AddSingleton<IEmailService, IntegrationEmailService>();
        });
    }
}