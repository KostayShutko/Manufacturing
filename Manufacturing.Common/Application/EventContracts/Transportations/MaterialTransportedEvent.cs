namespace Manufacturing.Common.Application.EventContracts.Transportations;

public class MaterialTransportedEvent : BaseEvent
{
    public MaterialTransportedEvent(int materialId, Guid workflowId)
        : base(workflowId)
    {
        MaterialId = materialId;
    }

    public int MaterialId { get; }
}
