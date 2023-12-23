namespace Manufacturing.Common.Application.EventContracts.Processes;

public class ProcessCreatedEvent : BaseEvent
{
    public ProcessCreatedEvent(int processId)
    {
        ProcessId = processId;
    }

    public int ProcessId { get; }
}
