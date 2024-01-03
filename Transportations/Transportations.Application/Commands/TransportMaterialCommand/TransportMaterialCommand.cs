using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace Transportations.Application.Commands.TransportMaterialCommand;

public class TransportMaterialCommand : IRequest<ResponseResult>
{
    public TransportMaterialCommand(int workflowId, int materialId)
    {
        WorkflowId = workflowId;
        MaterialId = materialId;
    }

    public int WorkflowId { get; set; }

    public int MaterialId { get; }
}