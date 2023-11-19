namespace MatchmakingService.Dtos; 

// DTO for a player in the matchmaking service (including upcoming duels)
public record MatchmakingPlayer
{
    public int PlayerId { get; init; }
    public string PlayerName { get; init; }
    public decimal EloRating { get; init; }
    public DateTime LastDuelPlayedAt { get; init; }
    public List<UpcomingDuelDto> UpcomingDuels { get; init; }
}