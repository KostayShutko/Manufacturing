using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Entities;
using MediatR;

namespace Transportations.Application.Commands.TransportProductCommand;

public class TransportProductCommand : IRequest<ResponseResult>
{
    public TransportProductCommand(Guid workflowId, int productId, ProductCode productCode)
    {
        WorkflowId = workflowId;
        ProductId = productId;
        ProductCode = productCode;
    }

    public Guid WorkflowId { get; set; }

    public int ProductId { get; set; }

    public ProductCode ProductCode { get; }
}
