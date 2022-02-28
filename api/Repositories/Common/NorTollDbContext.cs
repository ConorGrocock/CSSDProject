using api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Common;
public class NorTollDbContext : DbContext
{

#nullable disable
    public DbSet<Account> Accounts { get; set; }
    public DbSet<SignInToken> SignInTokens { get; set; }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

#nullable enable
    public NorTollDbContext(DbContextOptions<NorTollDbContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<WeatherForecast>().HasKey(x => x.Id);
        builder.Entity<Address>().HasKey(x => x.Id);
        builder.Entity<Account>().HasKey(x => x.Id);
        builder.Entity<SignInToken>().HasKey(x => x.Id);

        builder.Entity<Account>()
            .HasOne(x => x.PostalAddress)
            .WithOne()
            .HasForeignKey<Account>(x => x.PostalAddressId)
            .IsRequired();

        builder.Entity<SignInToken>()
            .HasOne(x => x.Account)
            .WithOne()
            .HasForeignKey<SignInToken>(x => x.AccountId)
            .IsRequired();
    }
}