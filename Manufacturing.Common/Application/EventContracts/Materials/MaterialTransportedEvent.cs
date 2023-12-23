namespace Manufacturing.Common.Application.EventContracts.Materials
{
    public class MaterialTransportedEvent : BaseEvent
    {
        public MaterialTransportedEvent(int materialId)
        {
            MaterialId = materialId;
        }

        public int MaterialId { get; }
    }
}
