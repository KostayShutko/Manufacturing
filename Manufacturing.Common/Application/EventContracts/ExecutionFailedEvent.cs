namespace Manufacturing.Common.Application.EventContracts;

public class ExecutionFailedEvent : BaseEvent
{
    public ExecutionFailedEvent(Guid workflowId, string error) : base(workflowId)
    {
        Error = error;
    }

    public string Error { get; set; }
}