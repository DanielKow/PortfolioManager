using Microsoft.EntityFrameworkCore;
using PortfolioManager.Domain.ExchangeRates;
using PortfolioManager.Domain.Users;

namespace PortfolioManager.Infrastructure.Database;

public class PortfolioManagerContext : DbContext
{
    public DbSet<ExchangeRate> ExchangeRates { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ApiKey> ApiKeys { get; set; } 

    public PortfolioManagerContext(DbContextOptions<PortfolioManagerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiKey>()
            .HasKey(row => row.Key);

        modelBuilder.Entity<ExchangeRate>()
            .HasKey(row => row.Currency);
    }
}