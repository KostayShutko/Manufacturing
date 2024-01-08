namespace Manufacturing.Common.Application.EventContracts.Products;

public class ProductPlacedEvent : BaseEvent
{
    public ProductPlacedEvent(Guid workflowId) : base(workflowId)
    {
    }
}
