using api.Models.Entities;
using api.Repositories.Common;
using api.Repositories.Common.Interfaces;

namespace api.Repositories;

public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(NorTollDbContext norTollDbContext) : base(norTollDbContext) { }
}