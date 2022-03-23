using api.Models.Entities;
using api.Models.Enums;
using api.Models.Exceptions;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class BillService : IBillService
{
    public Task<Bill[]> GetBillsFromInvoice(Guid invoiceId)
    {
        throw new NotImplementedException();
    }

    public Task<Bill> GetBill(Guid billId)
    {
        throw new NotImplementedException();
    }
}