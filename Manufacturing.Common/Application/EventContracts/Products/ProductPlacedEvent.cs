namespace Manufacturing.Common.Application.EventContracts.Products;

public class ProductPlacedEvent : BaseEvent
{
    public ProductPlacedEvent(int workflowId) : base(workflowId)
    {
    }
}
