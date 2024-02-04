namespace Manufacturing.Common.Application.EventContracts.Materials;

public class CancelMaterialReservationCommandEvent : BaseEvent
{
    public CancelMaterialReservationCommandEvent(int materialId, Guid workflowId)
        : base(workflowId)
    {
        MaterialId = materialId;
    }

    public int MaterialId { get; }
}