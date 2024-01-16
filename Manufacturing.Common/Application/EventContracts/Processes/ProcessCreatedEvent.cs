namespace Manufacturing.Common.Application.EventContracts.Processes;

public class ProcessCreatedEvent : BaseEvent
{
    public ProcessCreatedEvent(int processId, Guid workflowId)
        : base(workflowId)
    {
        ProcessId = processId;
    }

    public int ProcessId { get; set; }
}
