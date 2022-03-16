using System;
using System.Net.Http;
using System.Threading.Tasks;
using api.Controllers;
using static Tests.Integration.Common.Utilities;

namespace Tests.Integration.Actions;

public static class InvoiceActions
{
    private static readonly string Endpoint = Endpoint<InvoiceController>();

    public static async Task<(HttpResponseMessage, string)> StartInvoicePayment(this HttpClient client, Guid invoiceId)
    {
        var response = await client.GetAsync($"{Endpoint}/payment/{invoiceId}");

        return (response, await response.Content.ReadAsStringAsync());
    }

    public static async Task<HttpResponseMessage> ConfirmInvoicePayment(this HttpClient client, string token)
        => await client.PostAsync($"{Endpoint}/confirmation/{token}", null);
}