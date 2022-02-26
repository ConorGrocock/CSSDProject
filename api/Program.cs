using api.Repositories.Common;
using api.Repositories;
using api.Services;
using api.Services.Interfaces;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContextPool<NorTollDbContext>(opt =>
    opt.UseInMemoryDatabase("api")
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup dependencies
builder.Services
    .AddTransient<NorTollDbContext>()
    .AddTransient<IWeatherForecastRepository, WeatherForecastRepository>()
    .AddTransient<IWeatherService, WeatherService>();

if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddConsole();

    builder.Services.AddTransient<IEmailService, TestEmailService>();
}

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();