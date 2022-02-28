using api.Models.Entities;
using api.Repositories.Common;
using api.Repositories.Common.Exceptions;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(NorTollDbContext norTollDbContext) : base(norTollDbContext) { }

    public async Task<Account> GetByEmail(
        string email,
        Func<IQueryable<Account>, IQueryable<Account>>? query = null)
    {
        return await
            ApplyQuery(query)
            .SingleOrDefaultAsync(x => x.Email == email)
            ?? throw new EntityNotFoundException<Account>(nameof(Account.Email), email);
    }
}