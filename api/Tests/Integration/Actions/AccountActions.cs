using System.Net.Http;
using System.Threading.Tasks;
using api.Controllers;
using api.Models.Dtos;
using Tests.Integration.Common;
using static Tests.Integration.Common.Utilities;

namespace Tests.Integration.Actions;

public static class AccountActions
{
    private static readonly string Endpoint = Endpoint<AccountController>();

    public static async Task<HttpResponseMessage> CreateAccount(
        this HttpClient client,
        CreateAccountDto dto
    ) => await client.PostAsync(Endpoint, ToJsonContent(dto));
}