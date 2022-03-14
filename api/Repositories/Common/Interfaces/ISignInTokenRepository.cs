using api.Models.Entities;

namespace api.Repositories.Common.Interfaces;

public interface ISignInTokenRepository : IBaseRepository<SignInToken>, ITokenRepository<SignInToken> { }