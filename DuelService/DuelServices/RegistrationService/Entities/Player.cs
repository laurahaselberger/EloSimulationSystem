using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RegistrationService.Entities;

[Table("Player")]
public class Player
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id"), Required]
    public int Id { get; set; }
    
    [Required, StringLength(255)]
    [Column("Name")]
    public string Name { get; set; }
    
    [Required]
    [Column("EloRating")]
    public decimal EloRating { get; set; }
}