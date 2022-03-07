using api.Models.Common;

namespace api.Repositories.Common.Interfaces;

public interface ITokenRepository<T> where T : IToken
{
    public Task<T> GetByValue(
        string value,
        Func<IQueryable<T>, IQueryable<T>>? query = null);
}