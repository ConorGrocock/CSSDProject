using System.Net.Http;
using System.Threading.Tasks;
using api.Controllers;
using api.Models.Dtos;
using Tests.Integration.Common;
using static Tests.Integration.Common.Utilities;

namespace Tests.Integration.Actions;

public static class AuthActions
{
    private static readonly string Endpoint = Endpoint<AuthController>();

    public static async Task<HttpResponseMessage> RequestAuthentication(
        this HttpClient client,
        string email
    ) => await client.PostAsync($"{Endpoint}/request?email={email}", null);

    public static async Task<(HttpResponseMessage, TokenDto?)> VerifyAuthentication(
        this HttpClient client,
        string token
    )
    {
        var response = await client.PostAsync($"{Endpoint}/verify?token={token}", null);

        return (response, await response.Content.ReadAsAsync<TokenDto>());
    }
}