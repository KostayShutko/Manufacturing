namespace Manufacturing.Common.Application.EventContracts.Processes;

public class CancelProcessCommandEvent : BaseEvent
{
    public CancelProcessCommandEvent(int processId, Guid workflowId)
        : base(workflowId)
    {
        ProcessId = processId;
    }

    public int ProcessId { get; set; }
}
