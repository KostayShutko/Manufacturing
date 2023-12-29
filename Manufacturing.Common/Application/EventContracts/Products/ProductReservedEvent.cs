namespace Manufacturing.Common.Application.EventContracts.Products;

public class ProductReservedEvent : BaseEvent
{
    public ProductReservedEvent(int workflowId) : base(workflowId)
    {
    }
}
