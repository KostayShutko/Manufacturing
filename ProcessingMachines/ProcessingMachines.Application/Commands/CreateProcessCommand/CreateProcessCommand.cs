using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace ProcessingMachines.Application.Commands.CreateProcessCommand;

public class CreateProcessCommand : IRequest<ResponseResult<int>>
{
    public CreateProcessCommand(int materialId, Guid workflowId)
    {
        MaterialId = materialId;
        WorkflowId = workflowId;
    }

    public Guid WorkflowId { get; set; }

    public int MaterialId { get; }
}
