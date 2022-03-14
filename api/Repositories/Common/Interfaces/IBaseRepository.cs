using api.Models.Common;

namespace api.Repositories.Common.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    public Task<IQueryable<T>> GetAll(
        Func<IQueryable<T>, IQueryable<T>>? query = null
    );
    public Task<T> Get(
        Guid id,
        Func<IQueryable<T>, IQueryable<T>>? query = null);

    public Task Insert(T t);
    public Task Update(T t);
    public Task Delete(Guid id);
}
