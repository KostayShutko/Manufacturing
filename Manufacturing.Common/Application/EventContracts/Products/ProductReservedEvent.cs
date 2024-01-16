namespace Manufacturing.Common.Application.EventContracts.Products;

public class ProductReservedEvent : BaseEvent
{
    public ProductReservedEvent(int productId, Guid workflowId)
            : base(workflowId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}
