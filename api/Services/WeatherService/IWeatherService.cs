using api.Models;

namespace api.Services.Interfaces;

public interface IWeatherService
{
    public Task<WeatherForecast[]> GetWeatherForecast();

    public Task Insert(WeatherForecast weatherForecast);
}