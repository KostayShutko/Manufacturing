namespace Manufacturing.Common.Application.EventContracts.Materials
{
    public class MaterialReservationFailedEvent : BaseEvent
    {
        public MaterialReservationFailedEvent(Guid workflowId) : base(workflowId)
        {
        }
    }
}
