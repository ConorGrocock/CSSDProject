using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.Integration.Common;

public abstract class BaseTest
{
    private readonly Uri DefaultBaseAddress = new WebApplicationFactoryClientOptions().BaseAddress;
    protected readonly HttpClient _client;

    public BaseTest(string endpoint)
    {
        _client = new WebApplicationFactory<Program>().CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri(DefaultBaseAddress, $"api/{endpoint}")
        });
    }
    protected StringContent ToStringContent<T>(T payload) where T : class
        => new StringContent(JsonSerializer.Serialize(payload), null, "application/json");
}