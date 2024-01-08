using Manufacturing.Common.Domain.Entities;

namespace Manufacturing.Common.Application.EventContracts.Processes;

public class ProductProducedEvent : BaseEvent
{
    public ProductProducedEvent(ProductCode productCode, Guid workflowId)
        : base(workflowId)
    {
        ProductCode = productCode;
    }

    public ProductCode ProductCode { get; set; }
}
