using System.Threading.Tasks;
using Tests.Integration.Common;
using Xunit;
using System.Net;
using Tests.Integration.Actions;
using static Tests.Integration.Common.Utilities;
using Microsoft.Extensions.DependencyInjection;
using api.Services.Common.Interfaces;
using Tests.Integration.Services;
using System.Linq;
using System;

namespace Tests.Integration;

public class InvoiceTests
{
    [Fact]
    public async Task CanStartPayment()
    {
        var app = CreateApp();
        var client = app.CreateClient();

        // Arrange
        await client.Authenticate(app, SeedData.DriverEmail);

        // Act
        var (response, redirectUrl) = await client.StartInvoicePayment(SeedData.Invoice1Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(redirectUrl);
        Assert.True(Uri.IsWellFormedUriString(redirectUrl, UriKind.Absolute));
    }

    [Fact]
    public async Task CanConfirmPayment()
    {
        var app = CreateApp();
        var client = app.CreateClient();

        // Arrange
        await client.Authenticate(app, SeedData.DriverEmail);

        var (_, redirectUrl) = await client.StartInvoicePayment(SeedData.Invoice1Id);
        var token = redirectUrl[^36..];

        // Act
        var response = await client.ConfirmInvoicePayment(token);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}