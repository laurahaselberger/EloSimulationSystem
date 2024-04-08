using Microsoft.AspNetCore.Mvc;
using ProjectClassLibrary.Entities;
using ProjectClassLibrary.Entities.DTO;
using ProjectClassLibrary.Entities.Enums;
using WebApp.Services;
namespace WebApp.Controller;

[ApiController]
[Route("registration")]
public class ProjectController : ControllerBase
{
    public static ManagementProject MProject;
    public static RequestFundingProject RProject;
    [HttpPost("management")]
    public async Task<ActionResult<AProject>> CreateManagementProjectAsync(CreateManagementProjectDto dto)
    {
        ELawType lawType = ELawType.P_27;
        switch (dto.lawType)
        {
            case "p_27":
                lawType = ELawType.P_27;
                break;
            case "p_28":
                lawType = ELawType.P_28;
                break;
            case "p_29":
                lawType = ELawType.P_29;
                break;
        }
        Facility facility = new Facility() {FacilityName = dto.facility};
        MProject = new()
        {
            Facility = facility,
            Title = dto.title,
            Description = dto.description,
            LawType = lawType,
        };
        SendToFacility sender = new SendToFacility();
        sender.Publish(MProject);
        return Ok(MProject);
    }
    [HttpPost("funding")]
    public async Task<ActionResult<AProject>> CreateFundingProjectAsync(CreateFundingProjectDto dto)
    {
        Facility facility = new Facility() {FacilityName = dto.facility};
        RProject = new()
        {
            Facility = facility,
            Title = dto.title,
            Description = dto.description,
            IsFWFFunded = dto.isFWFFunded,
            IsFFGFunded = dto.isFFGFunded,
            IsEUFunded = dto.isEUFunded
        };
        SendToFacility sender = new SendToFacility();
        sender.Publish(RProject);
        return Ok(RProject);
    }
}