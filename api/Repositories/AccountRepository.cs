using api.Models.Entities;
using api.Repositories.Common;
using api.Repositories.Common.Interfaces;

namespace api.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(NorTollDbContext norTollDbContext) : base(norTollDbContext) { }
}