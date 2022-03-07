using api.Models.Common;
using api.Models.Exceptions;

namespace api.Repositories.Common.Exceptions
{
    public class EntityNotFoundException<T> : NotFoundException where T : BaseEntity
    {
        public EntityNotFoundException(string field, string expectedValue)
            : base($"{typeof(T).Name} with {field}={expectedValue} was not found") { }
    }
}
