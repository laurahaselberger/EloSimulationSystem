namespace PlayerStatisticsService.Dtos;

// Represents the data to update player statistics after a duel
public record UpdateStatsDto
{
    public int PlayerId { get; init; }
    public int NumberOfDuelsWon { get; init; }
    public int NumberOfDuelsLost { get; init; }
    public int NumberOfDuelsDraw { get; init; }
    public int NumberOfDuelsPlayed { get; init; }
    public int? AverageDuelDuration { get; init; }
    public DateTime? LastDuelPlayedAt { get; init; }
}