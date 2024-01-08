namespace Manufacturing.Common.Application.EventContracts.Products;

public class ProductReservedEvent : BaseEvent
{
    public ProductReservedEvent(Guid workflowId) : base(workflowId)
    {
    }
}
