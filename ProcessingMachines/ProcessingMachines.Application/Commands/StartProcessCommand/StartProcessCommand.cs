using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Entities;
using MediatR;

namespace ProcessingMachines.Application.Commands.StartProcessCommand;

public class StartProcessCommand : IRequest<ResponseResult>
{
    public StartProcessCommand(int processId, ProductCode productCode)
    {
        ProcessId = processId;
        ProductCode = productCode;
    }

    public int ProcessId { get; }

    public ProductCode ProductCode { get; set; }
}
