using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace ProcessingMachines.Application.Commands.StartProcessCommand;

public class StartProcessCommand : IRequest<ResponseResult>
{
    public StartProcessCommand(int processId)
    {
        ProcessId = processId;
    }

    public int ProcessId { get; }
}
