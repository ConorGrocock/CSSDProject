using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Common
{
    public class NorTollDbContext : DbContext
    {
#pragma warning disable 8618
        public NorTollDbContext(DbContextOptions<NorTollDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
