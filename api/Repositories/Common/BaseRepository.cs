using api.Models.Common;
using api.Repositories.Common;
using api.Repositories.Common.Exceptions;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly NorTollDbContext _norTollDbContext;
    protected DbSet<T> Set { get; }

    public BaseRepository(NorTollDbContext norTollDbContext)
    {
        _norTollDbContext = norTollDbContext;

        Set = _norTollDbContext.Set<T>();
    }

    public Task<IQueryable<T>> GetAll()
    {
        return Task.FromResult(Set.AsQueryable());
    }

    public async Task<T> Get(int id, Func<IQueryable<T>, IQueryable<T>>? query = null)
    {
        return await (query is null ? Set : query(Set))
            .SingleOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException<T>(nameof(BaseEntity.Id), id.ToString());
    }

    public async Task Insert(T t)
    {
        Set.Add(t);

        await _norTollDbContext.SaveChangesAsync();
    }

    public async Task Update(T t)
    {
        _norTollDbContext.Entry(t).State = EntityState.Modified;

        await _norTollDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        _norTollDbContext.Entry(await Get(id)).State = EntityState.Deleted;

        await _norTollDbContext.SaveChangesAsync();
    }

    protected IQueryable<T> ApplyQuery(Func<IQueryable<T>, IQueryable<T>>? query)
    {
        return query is null ? Set : query(Set);
    }
}
