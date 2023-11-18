using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerStatisticsService.Entities; 

public class Player
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }
    [Required, StringLength(255)]
    [Column("Name")]
    public string Name { get; set; }
    [Required]
    [Column("EloRating")]
    public decimal EloRating { get; set; }
}
