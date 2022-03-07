using api.Models.Entities;

namespace api.Repositories.Common.Interfaces;

public interface ISignInTokenRepository : IBaseRepository<SignInToken>
{
    public Task<SignInToken> GetByValue(
        string value,
        Func<IQueryable<SignInToken>, IQueryable<SignInToken>>? query = null);
}