namespace MatchmakingService.Dtos; 

// DTO for upcoming duels in matchmaking
public record UpcomingDuelDto
{
    public int Player1Id { get; init; }
    public int Player2Id { get; init; }
    public decimal EloDifference { get; init; }
    public DateTime ScheduledTime { get; init; }
}