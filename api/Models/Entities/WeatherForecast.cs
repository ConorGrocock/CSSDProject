using api.Models.Common;

namespace api.Models.Entities;
public class WeatherForecast : BaseEntity
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
}
