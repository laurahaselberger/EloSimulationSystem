namespace MatchmakingService.Dtos; 

// DTO for the outcome after a duel
public record DuelOutcomeDto
{
    public int WinnerId { get; init; }
    public int LoserId { get; init; }
    public bool IsDraw { get; init; }
}