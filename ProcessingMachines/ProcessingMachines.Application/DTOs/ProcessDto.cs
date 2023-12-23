using Manufacturing.Common.Application.DTOs;

namespace ProcessingMachines.Application.DTOs;

public class ProcessDto : BaseEntityDto
{
    public string State { get; set; }

    public int MaterialId { get; set; }

    public DateTime StartedOn { get; set; }

    public DateTime CompletedOn { get; set; }
}
