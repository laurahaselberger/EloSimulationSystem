namespace PlayerStatisticsService.Entities; 

public record UpdateStatsDto(int PlayerId, int NumberOfDuelsWon, int NumberOfDuelsLost, int NumberOfDuelsDraw, int NumberOfDuelsPlayed, int? AverageDuelDuration, DateTime? LastDuelPlayedAt);

public record PlayerStatisticsDto(int PlayerId, string PlayerName, decimal CurrentEloRating, int NumberOfDuelsWon, int NumberOfDuelsLost, int NumberOfDuelsDraw, int NumberOfDuelsPlayed, int? AverageDuelDuration, DateTime? LastDuelPlayedAt);