namespace DuelService; 

public class DuelResult
{
    public int PlayerId { get; set; }
    public int WinnerId { get; set; }
    public bool IsDraw { get; set; }
    public int EloDelta { get; set; }
}