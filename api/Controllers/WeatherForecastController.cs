using api.Models.Entities;
using api.Services.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Authorize]
public class WeatherForecastController : NorTollControllerBase
{
    private readonly IWeatherService _weatherService;
    private readonly IEmailService _emailService;

    public WeatherForecastController(IWeatherService weatherService, IEmailService emailService)
    {
        _weatherService = weatherService;
        _emailService = emailService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _weatherService.GetWeatherForecast();
    }

    [HttpPost]
    public async Task Post(WeatherForecast weatherForecast)
    {
        await _weatherService.Insert(weatherForecast);
    }
}