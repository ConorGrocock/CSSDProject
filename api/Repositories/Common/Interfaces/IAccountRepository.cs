using api.Models.Entities;

namespace api.Repositories.Common.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    public Task<Account> GetByEmail(
        string email,
        Func<IQueryable<Account>, IQueryable<Account>>? query = null);
}