using api.Models.Entities;
using api.Repositories.Interfaces;

namespace api.Repositories.Common.Interfaces;

public interface ISignInTokenRepository : IBaseRepository<SignInToken>
{
    public Task<SignInToken> GetByValue(string value);
}