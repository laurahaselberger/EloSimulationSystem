using Microsoft.EntityFrameworkCore;
using RegistrationService.Entities;

public class MatchmakingDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    
    public MatchmakingDbContext(DbContextOptions<MatchmakingDbContext> options) : base(options)
    {
    }
}