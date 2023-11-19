namespace RegistrationService.Dtos; 

// Represents the data needed to create a new player
public record PlayerDto
{
    public string Name { get; init; }
}