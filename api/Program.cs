using api.Repositories.Common;
using api.Repositories;
using api.Services;
using api.Services.Interfaces;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
=======
using api.Services.Common.Interfaces;
using api.Models.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;
using api.Models.Entities;
using api.Models.Enums;

public class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var isDevelopment = builder.Environment.IsDevelopment();

        builder.Services.AddDbContextPool<NorTollDbContext>(opt =>
            opt.UseInMemoryDatabase("api")
        );

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            // https://swagger.io/docs/specification/authentication/bearer-authentication/
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header,
                Name = HeaderNames.Authorization,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Provided by /auth/request and /auth/verify",
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                    },
                    Array.Empty<string>()
                }
            });
        });

        ConfigureConfiguration(builder);
        ConfigureRepositoryDependencies(builder);
        ConfigureServiceDependencies(builder);
        ConfigureAuthentication(builder, isDevelopment);

        if (isDevelopment)
        {
            ConfigureTestDependencies(builder);
        }

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        if (isDevelopment)
        {
            app.UseSwagger().UseSwaggerUI();

            await SeedDatabase(app);
        }
>>>>>>> 97c959b (Data Seeding (#20))

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

<<<<<<< HEAD
app.MapControllers();
=======
                opt.RequireHttpsMetadata = !isDevelopment;
            });
    }

    private static async Task SeedDatabase(WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<NorTollDbContext>();
        var dateTimeService = scope.ServiceProvider.GetRequiredService<IDateTimeService>();

        var idCounter = 1;

        var driverAddress = new Address
        {
            Id = ++idCounter,
            Line1 = "4 Grass Lane",
            City = "Sheffield",
            Country = "England",
            Postcode = "S16HU"
        };

        var driver = new Account
        {
            Id = ++idCounter,
            Name = "john the driver",
            Email = "john@email.com",
            Role = Role.Driver,
            PostalAddressId = driverAddress.Id
        };

        var tollOperatorAddress = new Address
        {
            Id = ++idCounter,
            Line1 = "12 High Lane",
            City = "Buxton",
            Country = "England",
            Postcode = "SK171SB"
        };

        var tollOperator = new Account
        {
            Id = ++idCounter,
            Name = "steve the toll operator",
            Email = "steve@email.com",
            Role = Role.TollOperator,
            PostalAddressId = tollOperatorAddress.Id
        };

        var createInvoice = (int[] billAmounts) =>
        {
            var invoice = new Invoice
            {
                Id = ++idCounter,
                AccountId = driver.Id,
                PostalAddressId = driverAddress.Id,
                PaymentReference = Guid.NewGuid().ToString(),
                IssuedAt = dateTimeService.Now()
            };

            invoice.Bills.AddRange(billAmounts.Select(amt => new Bill
            {
                Id = ++idCounter,
                Amount = amt,
                IssuedAt = dateTimeService.Now(),
            }));

            return invoice;
        };

        await dbContext.AddRangeAsync(
            driverAddress,
            tollOperatorAddress,
            driver,
            tollOperator,
            createInvoice(new[] { 13, 20, 5 }),
            createInvoice(new[] { 3 }),
            createInvoice(new[] { 34, 27 }));

        await dbContext.SaveChangesAsync();
    }
}
>>>>>>> 97c959b (Data Seeding (#20))

app.Run();