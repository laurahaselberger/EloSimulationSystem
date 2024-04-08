namespace ProjectClassLibrary.Entities;
public class RequestFundingProject : AProject
{
    public bool IsFWFFunded { get; set; }
    public bool IsFFGFunded { get; set; }
    public bool IsEUFunded { get; set; }
}