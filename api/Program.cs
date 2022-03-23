using api.Repositories.Common;
using api.Repositories;
using api.Services;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using api.Services.Common.Interfaces;
using api.Models.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;
using api.Models.Entities;
using api.Models.Enums;
using System.IdentityModel.Tokens.Jwt;
using api.Services.Common;

public class Program
{
    static string CorsPolicyName = "corsPolicy";

    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var isDevelopment = builder.Environment.IsDevelopment();

        builder.Services.AddDbContextPool<NorTollDbContext>(opt =>
            opt.UseInMemoryDatabase(
                GetOptions<ConfigurationOptions>(builder).DatabaseName
                ?? "NorTollDatabase")
        );

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName, builder =>
            {
                builder.AllowAnyOrigin();
            });
        });
        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            // https://swagger.io/docs/specification/authentication/bearer-authentication/
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header,
                Name = HeaderNames.Authorization,
                Scheme = "bearer",
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

        ConfigureOptions(builder);
        ConfigureRepositoryDependencies(builder);
        ConfigureServiceDependencies(builder);
        ConfigureAuthentication(builder, isDevelopment);

        if (isDevelopment)
        {
            ConfigureTestDependencies(builder);
        }

        var app = builder.Build();
        
        app.UseHttpsRedirection();

        app.UseCors(CorsPolicyName);

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        if (isDevelopment)
        {
            app.UseSwagger().UseSwaggerUI();

            await SeedDatabase(app);
        }

        app.Run();
    }
    private static void ConfigureRepositoryDependencies(WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<NorTollDbContext>()
            .AddTransient<IAccountRepository, AccountRepository>()
            .AddTransient<ISignInTokenRepository, SignInTokenRepository>()
            .AddTransient<IWeatherForecastRepository, WeatherForecastRepository>()
            .AddTransient<IInvoiceRepository, InvoiceRepository>()
            .AddTransient<IPaymentConfirmationTokenRepository, PaymentConfirmationTokenRepository>();
    }
    private static void ConfigureServiceDependencies(WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<IIdentityService, IdentityService>()
            .AddTransient<IWeatherService, WeatherService>()
            .AddTransient<IDateTimeService, DateTimeService>()
            .AddTransient<IInvoiceService, InvoiceService>()
            .AddTransient<IExternalPaymentProviderService, TestExternalPaymentProviderService>()
            .AddTransient<IBillService, BillService>();
    }
    private static void ConfigureTestDependencies(WebApplicationBuilder builder)
    {
        builder.Logging.AddConsole();

        builder.Services.AddTransient<IEmailService, TestEmailService>();
    }

    private static void ConfigureOptions(WebApplicationBuilder builder)
    {
        void ConfigureOptions<T>() where T : class
        {
            var options = GetOptions<T>(builder);

            if (options is null) { return; }

            builder.Services.AddSingleton(options);
        }

        ConfigureOptions<ConfigurationOptions>();
        ConfigureOptions<AuthenticationOptions>();
        ConfigureOptions<PaymentOptions>();
    }

    private static T GetOptions<T>(WebApplicationBuilder builder) where T : class
    {
        return builder.Configuration
            .GetSection(typeof(T).Name.Replace("Options", ""))
            .Get<T>();
    }

    private static void ConfigureAuthentication(WebApplicationBuilder builder, bool isDevelopment)
    {
        // prevent mapping away from NorTollClaimNames
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                var authenticationOptions = GetOptions<AuthenticationOptions>(builder);

                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authenticationOptions.JwtIssuer,

                    ValidateAudience = true,
                    ValidAudience = authenticationOptions.JwtAudience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authenticationOptions.JwtSecretKey,

                    ValidateLifetime = true,

                    NameClaimType = NorTollClaimNames.Name,
                    RoleClaimType = NorTollClaimNames.Role
                };

                opt.RequireHttpsMetadata = !isDevelopment;
            });
    }

    private static async Task SeedDatabase(WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<NorTollDbContext>();
        var dateTimeService = scope.ServiceProvider.GetRequiredService<IDateTimeService>();

        var driverAddress = new Address
        {
            Id = SeedData.DriverAddressId,
            Line1 = "4 Grass Lane",
            City = "Sheffield",
            Country = "England",
            Postcode = "S16HU"
        };

        var driver = new Account
        {
            Id = SeedData.DriverId,
            Name = "john the driver",
            Email = SeedData.DriverEmail,
            Role = Role.Driver,
            PostalAddressId = driverAddress.Id
        };

        var tollOperatorAddress = new Address
        {
            Id = SeedData.TollOperatorAddressId,
            Line1 = "12 High Lane",
            City = "Buxton",
            Country = "England",
            Postcode = "SK171SB"
        };

        var tollOperator = new Account
        {
            Id = SeedData.TollOperatorId,
            Name = "steve the toll operator",
            Email = SeedData.TollOperatorEmail,
            Role = Role.TollOperator,
            PostalAddressId = tollOperatorAddress.Id
        };

        var createInvoice = (Guid id, int[] billAmounts) =>
        {
            var invoice = new Invoice
            {
                Id = id,
                AccountId = driver.Id,
                PostalAddressId = driverAddress.Id,
                PaymentReference = Guid.NewGuid().ToString(),
                IssuedAt = dateTimeService.Now()
            };

            invoice.Bills.AddRange(billAmounts.Select(amt => new Bill
            {
                Id = Guid.NewGuid(),
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
            // createInvoice(new[] { 13, 20, 5 }),
            // createInvoice(new[] { 3 }),
            createInvoice(SeedData.Invoice1Id, new[] { 34, 27 }));

        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch { } // discard failed seed
    }
}

public static class SeedData
{
    public static Guid DriverAddressId { get; } = Guid.NewGuid();
    public static Guid DriverId { get; } = Guid.NewGuid();
    public static string DriverEmail { get; } = "driver@email.com";
    public static Guid TollOperatorAddressId { get; } = Guid.NewGuid();
    public static Guid TollOperatorId { get; } = Guid.NewGuid();
    public static string TollOperatorEmail { get; } = "tollOperator@email.com";
    public static Guid Invoice1Id { get; } = Guid.NewGuid();
}