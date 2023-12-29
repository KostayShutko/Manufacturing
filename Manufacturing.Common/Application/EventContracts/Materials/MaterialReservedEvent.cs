namespace Manufacturing.Common.Application.EventContracts.Materials
{
    public class MaterialReservedEvent : BaseEvent
    {
        public MaterialReservedEvent(int materialId, int workflowId)
            : base(workflowId)
        {
            MaterialId = materialId;
        }

        public int MaterialId { get; }
    }
}
