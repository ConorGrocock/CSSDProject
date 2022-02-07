namespace api.Services.Interfaces;

public interface IWeatherService
{
    public WeatherForecast[] GetWeatherForcast();
}