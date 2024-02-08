namespace Manufacturing.Common.Application.EventContracts.Materials;

public class ReserveMaterialCommandEvent : BaseEvent
{
    public ReserveMaterialCommandEvent(Guid workflowId) : base(workflowId)
    {
    }
}
