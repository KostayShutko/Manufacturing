using Manufacturing.Common.Application.DTOs;
using Manufacturing.Common.Domain.Entities;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Application.DTOs;

public class ProcessDto : BaseEntityDto
{
    public ProcessState State { get; set; }

    public int MaterialId { get; set; }

    public DateTime StartedOn { get; set; }

    public DateTime CompletedOn { get; set; }

    public ProductCode ProductCode { get; set; }
}
