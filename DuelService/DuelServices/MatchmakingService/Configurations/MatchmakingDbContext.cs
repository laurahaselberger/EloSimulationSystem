using Microsoft.EntityFrameworkCore;
using RegistrationService.Entities;

public class MatchmakingDbContext : DbContext
{
    public MatchmakingDbContext(DbContextOptions<MatchmakingDbContext> options) : base(options)
    {
    }
}