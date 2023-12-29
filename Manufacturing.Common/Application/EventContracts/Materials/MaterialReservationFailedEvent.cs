namespace Manufacturing.Common.Application.EventContracts.Materials
{
    public class MaterialReservationFailedEvent : BaseEvent
    {
        public MaterialReservationFailedEvent(int workflowId) : base(workflowId)
        {
        }
    }
}
