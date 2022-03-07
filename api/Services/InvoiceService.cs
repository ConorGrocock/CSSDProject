using api.Models.Dtos;
using api.Services.Common.Interfaces;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<InvoiceDto>> GetInvoices()
    {
        var listOfInvoices = new List<InvoiceDto>();
        var invoices = await _invoiceRepository.GetAll();
        
        foreach (var invoice in invoices)
        {
            listOfInvoices.Add(InvoiceMapper.AdaptToDto(invoice));
        }
        
        return listOfInvoices;
    }

    public async Task<InvoiceDto> GetInvoice(int id)
    {
        var invoice = await _invoiceRepository.Get(id);
        return InvoiceMapper.AdaptToDto(invoice);
    }
}