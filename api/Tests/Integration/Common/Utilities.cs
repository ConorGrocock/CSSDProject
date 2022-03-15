using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using api.Controllers;

namespace Tests.Integration.Common;

public static class Utilities
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public static StringContent ToJsonContent<T>(T payload) where T : class
            => new StringContent(JsonSerializer.Serialize(payload), null, "application/json");
    public static string Endpoint<T>() where T : NorTollControllerBase
        => typeof(T).Name.Replace("Controller", "");

    public static async Task<T?> ReadAsAsync<T>(this HttpContent content)
        => await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync(), jsonSerializerOptions);
}