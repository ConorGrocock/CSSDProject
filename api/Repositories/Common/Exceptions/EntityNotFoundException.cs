namespace api.Repositories.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {

        public EntityNotFoundException(int id, string entityName)
            : base($"{entityName} with ID {id} was not found")
        {
        }
    }

    public class EntityNotFoundException<T> : EntityNotFoundException
    {
        public EntityNotFoundException(int id) : base(id, typeof(T).FullName ?? "Entity")
        {
        }
    }
}
