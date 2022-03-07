﻿using api.Models.Entities;
using api.Repositories.Interfaces;

namespace api.Repositories.Common.Interfaces
{
    public interface IWeatherForecastRepository : IBaseRepository<WeatherForecast>
    {
    }
}
