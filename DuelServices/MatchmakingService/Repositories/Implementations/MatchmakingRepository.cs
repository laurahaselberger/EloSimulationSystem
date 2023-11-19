using RegistrationService.Configurations;
using RegistrationService.Entities;
using RegistrationService.Repositories.Implementations;

namespace MatchmakingService.Repositories.Implementations;

public abstract class MatchmakingRepository : ARepository<Player>
{
    protected MatchmakingRepository(MatchmakingDbContext context) : base(context)
    {
    }
}