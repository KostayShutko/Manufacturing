using Manufacturing.Common.Application.DTOs;

namespace Transportations.Application.DTOs;

public class TransportationDto : BaseEntityDto
{
    public string From { get; set; }

    public string To { get; set; }
}
