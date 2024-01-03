using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Entities;
using MediatR;

namespace Transportations.Application.Commands.TransportProductCommand;

public class TransportProductCommand : IRequest<ResponseResult>
{
    public TransportProductCommand(int workflowId, ProductCode productCode)
    {
        WorkflowId = workflowId;
        ProductCode = productCode;
    }

    public int WorkflowId { get; set; }

    public ProductCode ProductCode { get; }
}
