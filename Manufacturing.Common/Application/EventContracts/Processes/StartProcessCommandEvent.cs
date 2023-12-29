namespace Manufacturing.Common.Application.EventContracts.Processes;

public class StartProcessCommandEvent : BaseEvent
{
    public StartProcessCommandEvent(int workflowId) : base(workflowId)
    {
    }
}
