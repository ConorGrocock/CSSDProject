using api.Models.Entities;
using api.Repositories.Common;
using api.Repositories.Common.Interfaces;

namespace api.Repositories;

public class BillRepository : BaseRepository<Bill>, IBillRepository
{
    public BillRepository(NorTollDbContext norTollDbContext) : base(norTollDbContext) { }
}