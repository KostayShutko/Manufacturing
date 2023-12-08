namespace Manufacturing.Common.Application.EventContracts
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
