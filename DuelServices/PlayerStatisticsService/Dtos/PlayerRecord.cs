using System.ComponentModel.DataAnnotations;

namespace PlayerStatisticsService.Dtos; 

public record CreatePlayerDto([StringLength(255)] string Name);
    
public record UpdatePlayerDto(int Id, [StringLength(255)] string Name);

public record PlayerDto(int Id, string Name, decimal EloRating);