using api.Models.Entities;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;

namespace api.Services;
public class WeatherService : IWeatherService
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public WeatherService(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<WeatherForecast[]> GetWeatherForecast()
    {
        return (await _weatherForecastRepository.GetAll()).ToArray();
    }

    public async Task Insert(WeatherForecast weatherForecast)
    {
        await _weatherForecastRepository.Insert(weatherForecast);
    }
}