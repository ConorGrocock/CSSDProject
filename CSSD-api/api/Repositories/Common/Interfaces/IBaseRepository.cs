using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public Task<IQueryable<T>> GetAll();
        public Task<T> Get(int id);

        public Task Insert(T t);
        public Task Update(T t);
        public Task Delete(int id);

        public Task Save();
    }
}
