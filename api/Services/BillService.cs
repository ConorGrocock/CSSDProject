using api.Models.Entities;
using api.Models.Enums;
using api.Models.Exceptions;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class BillService : IBillService
{
    private readonly IBillRepository _billRepository;

    public BillService(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public Task<Bill[]> GetBillsFromInvoice(Guid invoiceId)
    {
        throw new NotImplementedException();
    }

    public async Task<Bill> GetBill(Guid billId)
    {
        return await _billRepository.Get(billId);
    }
}