using Manufacturing.Common.Domain.Entities;

namespace ProcessingMachines.API.Requests;

public class StartProcessRequest
{
    public ProductCode ProductCode { get; set; }
}