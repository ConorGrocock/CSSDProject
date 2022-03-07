using api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Common;
public class NorTollDbContext : DbContext
{

#nullable disable
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Journey> Journeys { get; set; }
    public DbSet<PaymentConfirmation> PaymentConfirmations { get; set; }
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
        builder.Entity<Bill>().HasKey(x => x.Id);
        builder.Entity<Journey>().HasKey(x => x.Id);
        builder.Entity<PaymentConfirmation>().HasKey(x => x.Id);

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
            .HasOne(x => x.Invoice)
            .WithOne()
            .HasForeignKey<Bill>(x => x.InvoiceId);

        builder.Entity<Bill>()
            .HasOne(x => x.Journey)
            .WithOne()
            .HasForeignKey<Bill>(x => x.JourneyId)
            .IsRequired();

        builder.Entity<Invoice>()
            .HasOne(x => x.PostalAddress)
            .WithOne()
            .HasForeignKey<Invoice>(x => x.PostalAddressId)
            .IsRequired();

        builder.Entity<Invoice>()
            .HasMany(x => x.Bills)
            .WithOne()
            .HasForeignKey(x => x.InvoiceId);

        builder.Entity<Bill>()
            .HasOne(x => x.Journey)
            .WithOne()
            .HasForeignKey<Bill>(x => x.JourneyId);

        builder.Entity<Invoice>()
            .HasOne(x => x.Account)
            .WithOne()
            .HasForeignKey<Invoice>(x => x.AccountId);

        builder.Entity<PaymentConfirmation>()
            .HasOne(x => x.Invoice)
            .WithOne()
            .HasForeignKey<PaymentConfirmation>(x => x.InvoiceId)
            .IsRequired();

        var account = new Account
        {
            Id = -1,
            Email = "qwe321",
            Name = "Test"
        };
    

        var invoice = new Invoice
        {
            Id = -1,
            AccountId = -1,
            PaymentReference = "dfsjkhdsfjdfjk",
            Amount = new decimal(12.21)
        };
        
        
        builder.Entity<Invoice>().HasData(invoice);
        
    }
}