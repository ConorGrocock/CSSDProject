using api.Models.Dtos;
using api.Models.Entities;
using api.Services.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class InvoiceController : NorTollControllerBase
{
    private readonly IInvoiceService _invoiceService;
    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public async Task<ViewInvoiceDto[]> Get()
    {
        return await _invoiceService.GetInvoices();
    }

    [HttpGet("{invoiceId}")]
    public async Task<ViewInvoiceDto> GetId([FromRoute] Guid invoiceId)
    {
        return await _invoiceService.GetInvoice(invoiceId);
    }

    [HttpGet("payment/{invoiceId}"), Authorize]
    public async Task<string> Payment([FromRoute] Guid invoiceId)
    {
        var redirectUri = await _invoiceService.Pay(invoiceId);

        return redirectUri.ToString();
    }

    [HttpPost("confirmation/{token}")]
    public async Task<ActionResult> PaymentConfirmation([FromRoute] string token)
    {
        await _invoiceService.ConfirmPayment(token);

        return NoContent();
    }
}