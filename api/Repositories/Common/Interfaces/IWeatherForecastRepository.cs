using api.Models;
using api.Repositories.Interfaces;

namespace api.Repositories.Common.Interfaces
{
    public interface IWeatherForecastRepository : IBaseRepository<WeatherForecast>
    {
    }
}
