using api.Models.Entities;

namespace api.Services.Common.Interfaces;
public interface IWeatherService
{
    public Task<WeatherForecast[]> GetWeatherForecast();

    public Task Insert(WeatherForecast weatherForecast);
}