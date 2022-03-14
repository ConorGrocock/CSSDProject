using api.Models.Common;

namespace api.Repositories.Common.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    public Task<IQueryable<T>> GetAll();
    public Task<T> Get(
        int id,
         Func<IQueryable<T>, IQueryable<T>>? query = null);

    public Task Insert(T t);
    public Task Update(T t);
    public Task Delete(int id);
}
