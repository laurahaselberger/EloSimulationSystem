namespace RegistrationService.Dtos; 

// Represents the data needed to update an existing player
public record UpdatePlayerDto
{
    public string Name { get; init; }
    public decimal EloRating { get; init; }
}