using api.Models.Entities;
using api.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Common;
public class NorTollDbContext : DbContext
{

#nullable disable
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<PaymentConfirmation> PaymentConfirmations { get; set; }
    public DbSet<PaymentConfirmationToken> PaymentConfirmationTokens { get; set; }
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
        builder.Entity<Invoice>().HasKey(x => x.Id);
        builder.Entity<Bill>().HasKey(x => x.Id);
        builder.Entity<PaymentConfirmation>().HasKey(x => x.Id);
        builder.Entity<PaymentConfirmationToken>().HasKey(x => x.Id);

        builder.Entity<Account>()
            .HasOne(x => x.PostalAddress)
            .WithOne()
            .HasForeignKey<Account>(x => x.PostalAddressId)
            .IsRequired();

        builder.Entity<SignInToken>()
            .HasOne(x => x.Account)
            .WithOne()
            .HasForeignKey<SignInToken>(x => x.AccountId);

        builder.Entity<Bill>()
           .HasOne<Invoice>(x => x.Invoice)
           .WithMany(x => x.Bills)
           .HasForeignKey(x => x.InvoiceId)
           .IsRequired();

        builder.Entity<Invoice>()
            .HasOne<Address>(x => x.PostalAddress)
            .WithMany()
            .HasForeignKey(x => x.PostalAddressId)
            .IsRequired();

        builder.Entity<Invoice>()
            .HasOne<Account>(x => x.Account)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.AccountId);

        builder.Entity<Invoice>()
            .HasOne(x => x.PaymentConfirmation)
            .WithOne(x => x.Invoice)
            .HasForeignKey<Invoice>(x => x.PaymentConfirmationId);

        builder.Entity<PaymentConfirmationToken>()
            .HasOne(x => x.Invoice)
            .WithOne()
            .HasForeignKey<PaymentConfirmationToken>(x => x.InvoiceId)
            .IsRequired();
    }
}