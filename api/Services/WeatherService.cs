using api.Repositories.Common.Interfaces;
using api.Services.Interfaces;

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

    public Task Insert(WeatherForecast weatherForecast)
    {
        _weatherForecastRepository.Insert(weatherForecast);

        return Task.CompletedTask;
    }
}