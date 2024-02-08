namespace Manufacturing.Common.Application.EventContracts;

public class BaseEvent
{
    public BaseEvent(Guid workflowId)
    {
        WorkflowId = workflowId;
    }

    public Guid WorkflowId { get; set; }
}
