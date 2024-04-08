using ProjectClassLibrary.Entities.Enums;
namespace ProjectClassLibrary.Entities;
public class AProject
{
    public Facility Facility { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public EProjectState ProjectState { get; set; } = EProjectState.CREATED;
}