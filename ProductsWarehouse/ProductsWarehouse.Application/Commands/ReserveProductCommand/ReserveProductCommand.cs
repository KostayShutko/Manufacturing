using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace ProductsWarehouse.Application.Commands.ReserveProductCommand;

public class ReserveProductCommand : IRequest<ResponseResult<int>>
{
    public ReserveProductCommand(int workflowId)
    {
        WorkflowId = workflowId;
    }

    public int WorkflowId { get; set; }
}
