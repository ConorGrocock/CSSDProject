using System.Linq.Expressions;
using api.Models.Entities;
using api.Repositories.Common;
using api.Repositories.Common.Exceptions;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class SignInTokenRepository : BaseRepository<SignInToken>, ISignInTokenRepository
{
    public SignInTokenRepository(NorTollDbContext norTollDbContext) : base(norTollDbContext) { }

    public async Task<SignInToken> GetByValue(
        string value,
        Func<IQueryable<SignInToken>, IQueryable<SignInToken>>? query = null)
    {
        return await
            ApplyQuery(query)
            .SingleOrDefaultAsync(x => x.Value == value)
            ?? throw new EntityNotFoundException<SignInToken>(nameof(SignInToken.Value), value);
    }
}