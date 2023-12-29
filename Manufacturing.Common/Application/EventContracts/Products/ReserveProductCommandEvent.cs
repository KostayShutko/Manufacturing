namespace Manufacturing.Common.Application.EventContracts.Products;

public class ReserveProductCommandEvent : BaseEvent
{
    public ReserveProductCommandEvent(int workflowId) : base(workflowId)
    {
    }
}
