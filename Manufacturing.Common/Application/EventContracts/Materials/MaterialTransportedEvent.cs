namespace Manufacturing.Common.Application.EventContracts.Materials
{
    public class MaterialTransportedEvent : BaseEvent
    {
        public MaterialTransportedEvent(int materialId, int workflowId)
            : base(workflowId)
        {
            MaterialId = materialId;
        }

        public int MaterialId { get; }
    }
}
