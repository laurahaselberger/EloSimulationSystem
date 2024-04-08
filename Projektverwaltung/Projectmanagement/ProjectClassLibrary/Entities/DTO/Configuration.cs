namespace ProjectClassLibrary.Entities.DTO;
public record CreateManagementProjectDto(string facility, string title, string description, string lawType);
public record CreateFundingProjectDto(string facility, string title, string description, bool isFWFFunded, bool isFFGFunded, bool isEUFunded );