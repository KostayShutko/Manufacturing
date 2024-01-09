using MassTransit;

namespace WorkflowOrchestrator.Domain.Entities;

public class ProductProductionWorkflowState : SagaStateMachineInstance, ISagaVersion
{
    public Guid CorrelationId { get; set; }

    public string CurrentState { get; set; }

    public int Version { get; set; }
}
