using api.Models.Entities;
using api.Repositories.Common;
using api.Repositories.Common.Interfaces;

namespace api.Repositories
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(NorTollDbContext norTollDbContext) : base(norTollDbContext)
        {
        }
    }
}
