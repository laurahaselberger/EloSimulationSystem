using Microsoft.EntityFrameworkCore;
using RegistrationService.Entities;

namespace RegistrationService.Configurations;

public class RegistrationServiceDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    
    public RegistrationServiceDbContext(DbContextOptions<RegistrationServiceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Player>()
            .HasIndex(p => p.Name)
            .IsUnique();
    }
}