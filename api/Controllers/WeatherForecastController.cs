using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
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