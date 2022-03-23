using api.Models.Dtos;
using api.Models.Entities;

namespace api.Services.Common.Interfaces;

public interface IInvoiceService
{
    public Task<ViewInvoiceDto[]> GetInvoices();
    public Task<Uri> Pay(Guid invoiceId);
    public Task ConfirmPayment(string token);
    public Task<Invoice> GetInvoice(Guid invoiceId);
}