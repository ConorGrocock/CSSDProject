using api.Models.Dtos;
using api.Services.Common.Interfaces;
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

    [HttpGet("/{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        return Ok(await _invoiceService.GetInvoice(id));
    }
}