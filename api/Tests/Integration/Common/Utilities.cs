using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using api.Controllers;
using api.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tests.Integration.Services;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration.Memory;
using Tests.Integration.Actions;
using System.Linq;
using System.Net.Http.Headers;

namespace Tests.Integration.Common;

public static class Utilities
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public static WebApplicationFactory<Program> CreateApp()
    {
        var app = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // unique database per-test
                // prevent data sharing 
                // prevent concurrency issues with in-memory db
                builder.ConfigureAppConfiguration((_, builder) =>
                {
                    var configurationSource = new MemoryConfigurationSource();

                    configurationSource.InitialData = new Dictionary<string, string>()
                    {
                        { "Configuration:DatabaseName", Guid.NewGuid().ToString() },
                    };

                    builder.Sources.Insert(0, configurationSource);
                });

                builder.ConfigureServices(opt =>
                {
                    // replace external services - they cannot be tested against
                    opt.RemoveAll<IEmailService>();
                    opt.AddSingleton<IEmailService, IntegrationEmailService>();
                });
            });

        app.ClientOptions.BaseAddress = new Uri("http://localhost/api/");
        app.ClientOptions.AllowAutoRedirect = false;

        return app;
    }

    public static async Task Authenticate(
        this HttpClient client,
        WebApplicationFactory<Program> app,
        string email)
    {
        await client.RequestAuthentication(email);

        using var scope = app.Services.CreateAsyncScope();
        var emailService = (IntegrationEmailService)scope.ServiceProvider.GetRequiredService<IEmailService>();

        var token = emailService
            .EmailItems
            .Single(x => x.To == email)
            .Message[^36..];

        var (_, tokenDto) = await client.VerifyAuthentication(token);

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenDto!.Token);
    }

    public static StringContent ToJsonContent<T>(T payload) where T : class
            => new StringContent(JsonSerializer.Serialize(payload), null, "application/json");
    public static string Endpoint<T>() where T : NorTollControllerBase
        => typeof(T).Name.Replace("Controller", "");

    public static async Task<T?> ReadAsAsync<T>(this HttpContent content)
        => await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync(), jsonSerializerOptions);
}