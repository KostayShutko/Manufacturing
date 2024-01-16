using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace Transportations.Application.Commands.TransportMaterialCommand;

public class TransportMaterialCommand : IRequest<ResponseResult>
{
    public TransportMaterialCommand(Guid workflowId, int materialId)
    {
        WorkflowId = workflowId;
        MaterialId = materialId;
    }

    public Guid WorkflowId { get; set; }

    public int MaterialId { get; }
}