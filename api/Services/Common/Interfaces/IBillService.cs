using System.Security.Policy;
using api.Models.Entities;

namespace api.Services.Common.Interfaces;

public interface IBillService
{
    public Task<Bill[]> GetBillsFromInvoice(Guid invoiceId);
    public Task<Bill> GetBill(Guid billId);
}