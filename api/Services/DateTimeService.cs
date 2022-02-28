using api.Services.Common.Interfaces;

namespace api.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now() => DateTime.UtcNow;
}