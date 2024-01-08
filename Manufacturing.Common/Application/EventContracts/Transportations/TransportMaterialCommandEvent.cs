namespace Manufacturing.Common.Application.EventContracts.Transportations;

public class TransportMaterialCommandEvent : BaseEvent
{
    public TransportMaterialCommandEvent(int materialId, Guid workflowId)
        : base(workflowId)
    {
        MaterialId = materialId;
    }

    public int MaterialId { get; }
}
