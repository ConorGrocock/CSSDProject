using api.Repositories.Common;
using api.Repositories;
using api.Services;
using api.Services.Interfaces;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextPool<NorTollDbContext>(opt => opt.UseInMemoryDatabase("api"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup dependencies
builder.Services
    .AddTransient<NorTollDbContext>()
    .AddTransient<IWeatherForecastRepository, WeatherForecastRepository>()
    .AddTransient<IWeatherService, WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();