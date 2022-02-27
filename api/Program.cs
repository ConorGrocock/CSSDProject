using api.Repositories.Common;
using api.Repositories;
using api.Services;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using api.Services.Common.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var isDevelopment = builder.Environment.IsDevelopment();

        builder.Services.AddControllers();
        builder.Services.AddDbContextPool<NorTollDbContext>(opt =>
            opt.UseInMemoryDatabase("api")
        );

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        ConfigureRepositoryDependencies(builder);
        ConfigureServiceDependencies(builder);

        if (isDevelopment)
        {
            ConfigureTestDependencies(builder);
        }

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            app
            .UseSwagger()
            .UseSwaggerUI();
        }

        app.Run();
    }
    private static void ConfigureRepositoryDependencies(WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<NorTollDbContext>()
            .AddTransient<IAccountRepository, AccountRepository>()
            .AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
    }
    private static void ConfigureServiceDependencies(WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<IIdentityService, IdentityService>()
            .AddTransient<IWeatherService, WeatherService>();
    }
    private static void ConfigureTestDependencies(WebApplicationBuilder builder)
    {
        builder.Logging.AddConsole();

        builder.Services.AddTransient<IEmailService, TestEmailService>();
    }
}