using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Entities;
using MediatR;

namespace ProductsWarehouse.Application.Commands.PlaceProductCommand;

public class PlaceProductCommand : IRequest<ResponseResult>
{
    public PlaceProductCommand(Guid workflowId, ProductCode productCode, int productId)
    {
        WorkflowId = workflowId;
        ProductId = productId;
        ProductCode = productCode;
    }

    public Guid WorkflowId { get; set; }

    public int ProductId { get; set; }

    public ProductCode ProductCode { get; }
}
