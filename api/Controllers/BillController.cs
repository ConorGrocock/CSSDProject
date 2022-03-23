using api.Models.Entities;
using api.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class BillController : NorTollControllerBase
{
    private readonly IBillService _billService;
    public BillController(IBillService billService)
    {
        _billService = billService;
    }

    [HttpGet("{billId:Guid}")]
    public async Task<ActionResult<Bill>> PaymentConfirmation(Guid billId)
    {
        return Ok(await _billService.GetBill(billId));
    }
}