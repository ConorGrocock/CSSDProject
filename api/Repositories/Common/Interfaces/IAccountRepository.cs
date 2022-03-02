using api.Models.Entities;
using api.Repositories.Interfaces;

namespace api.Repositories.Common.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    public Task<Account> GetByEmail(
        string email,
        Func<IQueryable<Account>, IQueryable<Account>>? query = null);
}