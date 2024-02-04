using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace ProcessingMachines.Application.Commands.CancelProcessCommand;

public class CancelProcessCommand : IRequest<ResponseResult>
{
    public CancelProcessCommand(int processId)
    {
        ProcessId = processId;
    }

    public int ProcessId { get; }
}