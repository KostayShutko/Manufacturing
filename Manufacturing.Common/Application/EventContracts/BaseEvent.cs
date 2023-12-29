namespace Manufacturing.Common.Application.EventContracts
{
    public class BaseEvent
    {
        public BaseEvent(int workflowId)
        {
            WorkflowId = workflowId;
        }

        public int WorkflowId { get; set; }
    }
}
