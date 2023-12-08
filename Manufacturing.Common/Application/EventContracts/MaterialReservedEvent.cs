namespace Manufacturing.Common.Application.EventContracts
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
