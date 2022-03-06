using api.Models.Dtos;
using api.Services.Common.Interfaces;
using api.Repositories.Common.Interfaces;

namespace api.Services;

public class InvoiceService : IInvoiceService
{
    private readonly ILogger<InvoiceService> _logger;
    private readonly IInvoiceRepository _invoiceRepository;
    public InvoiceService(ILogger<InvoiceService> logger, IInvoiceRepository invoiceRepository)
    {
        _logger = logger;
        _invoiceRepository = invoiceRepository;
    }

    public async Task<InvoiceDto> GetInvoices()
    {
        var invoices = await _invoiceRepository.GetAll();
        var invoiceDto = new InvoiceDto {Invoices = invoices};
        return invoiceDto;
    }
}