using Manufacturing.Common.Domain.Entities;

namespace Manufacturing.Common.Application.EventContracts.Transportations;

public class ProductTransportedEvent : BaseEvent
{
    public ProductTransportedEvent(int productId, ProductCode productCode, Guid workflowId)
        : base(workflowId)
    {
        ProductId = productId;
        ProductCode = productCode;
    }

    public int ProductId { get; set; }

    public ProductCode ProductCode { get; set; }
}