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

public class Program
{
    public static void Main(string[] args)
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

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger().UseSwaggerUI();
        }

        app.Run();
    }
    private static void ConfigureRepositoryDependencies(WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<NorTollDbContext>()
            .AddTransient<IAccountRepository, AccountRepository>()
            .AddTransient<ISignInTokenRepository, SignInTokenRepository>()
            .AddTransient<IInvoiceRepository, InvoiceRepository>()
            .AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
    }
    private static void ConfigureServiceDependencies(WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<IIdentityService, IdentityService>()
            .AddTransient<IWeatherService, WeatherService>()
            .AddTransient<IInvoiceService, InvoiceService>()
            .AddTransient<IDateTimeService, DateTimeService>();
    }
    private static void ConfigureTestDependencies(WebApplicationBuilder builder)
    {
        builder.Logging.AddConsole();

        builder.Services.AddTransient<IEmailService, TestEmailService>();
    }

    private static void ConfigureConfiguration(WebApplicationBuilder builder)
    {
        void ConfigureOptions<T>() where T : class
            => builder.Services.AddSingleton(GetOptions<T>(builder));

        ConfigureOptions<AuthenticationOptions>();
    }

    private static T GetOptions<T>(WebApplicationBuilder builder) where T : class
    {
        return builder.Configuration
            .GetSection(typeof(T).Name.Replace("Options", ""))
            .Get<T>();
    }

    private static void ConfigureAuthentication(WebApplicationBuilder builder, bool isDevelopment)
    {

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

                    ValidateLifetime = true
                };

                opt.RequireHttpsMetadata = !isDevelopment;
            });
    }
}