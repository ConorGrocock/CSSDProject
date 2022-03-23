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
    public async Task<ActionResult> Get()
    {
        return Ok(await _invoiceService.GetInvoices());
    }

    [HttpGet("{invoiceId}")]
    public async Task<ActionResult<Invoice>> GetId([FromRoute] Guid invoiceId)
    {
        return Ok(await _invoiceService.GetInvoice(invoiceId));
    }

    [HttpGet("payment/{invoiceId}"), Authorize]
    public async Task<ActionResult<string>> Payment([FromRoute] Guid invoiceId)
    {
        var redirectUri = await _invoiceService.Pay(invoiceId);

        return Ok(redirectUri.ToString());
    }

    [HttpPost("confirmation/{token}")]
    public async Task<ActionResult> PaymentConfirmation([FromRoute] string token)
    {
        await _invoiceService.ConfirmPayment(token);

        return NoContent();
    }
}