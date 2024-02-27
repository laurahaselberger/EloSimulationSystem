namespace PlayerStatisticsService.Dtos; 

// Represents the statistics data for a player
public record PlayerStatisticsDto
{
    public int PlayerId { get; init; }
    public string PlayerName { get; init; }
    public decimal CurrentEloRating { get; init; }
    public int NumberOfDuelsWon { get; init; }
    public int NumberOfDuelsLost { get; init; }
    public int NumberOfDuelsDraw { get; init; }
    public int NumberOfDuelsPlayed { get; init; }
    public int? AverageDuelDuration { get; init; }
    public DateTime? LastDuelPlayedAt { get; init; }
}