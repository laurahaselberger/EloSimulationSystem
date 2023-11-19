namespace MatchmakingService.Dtos; 

// DTO for player information in matchmaking
public record MatchmakingPlayerDto
{
    public int PlayerId { get; init; }
    public string PlayerName { get; init; }
    public decimal EloRating { get; init; }
    public DateTime LastDuelPlayedAt { get; init; }
}