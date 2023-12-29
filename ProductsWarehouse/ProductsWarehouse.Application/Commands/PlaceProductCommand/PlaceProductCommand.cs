using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Entities;
using MediatR;

namespace ProductsWarehouse.Application.Commands.PlaceProductCommand;

public class PlaceProductCommand : IRequest<ResponseResult>
{
    public PlaceProductCommand(int workflowId, ProductCode productCode)
    {
        WorkflowId = workflowId;
        ProductCode = productCode;
    }

    public int WorkflowId { get; set; }

    public ProductCode ProductCode { get; }
}
