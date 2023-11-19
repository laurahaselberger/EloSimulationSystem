using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegistrationService.Entities;

namespace PlayerStatisticsService.Entities; 

public class PlayerStatistic
{
    [Key, ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }

    [Required]
    [Column("NumberOfDuelsWon")]
    public int NumberOfDuelsWon { get; set; }

    [Required]
    [Column("NumberOfDuelsLost")]
    public int NumberOfDuelsLost { get; set; }

    [Required]
    [Column("NumberOfDuelsDraw")]
    public int NumberOfDuelsDraw { get; set; }

    [Required]
    [Column("NumberOfDuelsPlayed")]
    public int NumberOfDuelsPlayed { get; set; }

    [Column("AverageDuelDuration")]
    public int? AverageDuelDuration { get; set; }

    [Column("LastDuelPlayedAt")]
    public DateTime? LastDuelPlayedAt { get; set; }

    [Required]
    public Player Player { get; set; }
}