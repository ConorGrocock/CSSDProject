using System.Security.Policy;
using api.Models.Entities;

namespace api.Services.Common.Interfaces;

public interface IInvoiceService
{
    public Task<Invoice[]> GetInvoices();
    public Task<Uri> Pay(int invoiceId);
}