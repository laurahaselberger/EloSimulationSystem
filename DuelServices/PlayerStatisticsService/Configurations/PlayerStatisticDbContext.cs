using Microsoft.EntityFrameworkCore;
using PlayerStatisticsService.Entities;

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
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => ps.PlayerId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Player)
                .WithOne(p => p.PlayerStatistic)
                .HasForeignKey<PlayerStatistic>(ps => ps.PlayerId);
        }
    }
}