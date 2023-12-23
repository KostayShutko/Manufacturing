namespace Manufacturing.Common.Application.EventContracts.Materials
{
    public class MaterialReservedEvent : BaseEvent
    {
        public MaterialReservedEvent(int materialId)
        {
            MaterialId = materialId;
        }

        public int MaterialId { get; }
    }
}
