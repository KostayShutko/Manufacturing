using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace ProductsWarehouse.Application.Commands.ReserveProductCommand;

public class ReserveProductCommand : IRequest<ResponseResult<int>>
{
    public ReserveProductCommand(Guid workflowId)
    {
        WorkflowId = workflowId;
    }

    public Guid WorkflowId { get; set; }
}
