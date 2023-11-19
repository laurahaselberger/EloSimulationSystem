using Microsoft.EntityFrameworkCore;
using PlayerStatisticsService.Entities;
using RegistrationService.Entities;


namespace PlayerStatisticsService.Configurations
{
    public class PlayerStatisticDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public PlayerStatisticDbContext(DbContextOptions<PlayerStatisticDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => ps.PlayerId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Player)
                .WithOne()
                .HasForeignKey<PlayerStatistic>(ps => ps.PlayerId);
        }
    }
}