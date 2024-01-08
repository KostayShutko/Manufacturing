namespace Manufacturing.Common.Application.EventContracts.Products;

public class ReserveProductCommandEvent : BaseEvent
{
    public ReserveProductCommandEvent(Guid workflowId) : base(workflowId)
    {
    }
}
