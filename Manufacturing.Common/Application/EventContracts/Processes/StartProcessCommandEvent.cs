namespace Manufacturing.Common.Application.EventContracts.Processes;

public class StartProcessCommandEvent : BaseEvent
{
    public StartProcessCommandEvent(Guid workflowId) : base(workflowId)
    {
    }
}
