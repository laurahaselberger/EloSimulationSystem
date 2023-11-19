namespace RegistrationService.Dtos; 

// Represents the data returned when listing players
public record PlayerListDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public decimal EloRating { get; init; }
}