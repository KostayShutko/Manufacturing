namespace Manufacturing.Common.Application.EventContracts.Products;

public class CancelProductReservationCommandEvent : BaseEvent
{
    public CancelProductReservationCommandEvent(int productId, Guid workflowId)
        : base(workflowId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}
