using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlayerStatisticsService.Configurations;
using PlayerStatisticsService.Entities;
using PlayerStatisticsService.Repositories.Interfaces;


namespace PlayerStatisticsService.Repositories.Implementations; 

public class PlayerStatisticRepository : ARepository<PlayerStatistic>, IPlayerStatisticRepository
{
    public PlayerStatisticRepository(PlayerStatisticDbContext context) : base(context)
    {
    }
}
