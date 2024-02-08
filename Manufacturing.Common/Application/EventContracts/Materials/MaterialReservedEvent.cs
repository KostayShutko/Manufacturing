namespace Manufacturing.Common.Application.EventContracts.Materials;

public class MaterialReservedEvent : BaseEvent
{
    public MaterialReservedEvent(int materialId, Guid workflowId)
        : base(workflowId)
    {
        MaterialId = materialId;
    }

    public int MaterialId { get; }
}
