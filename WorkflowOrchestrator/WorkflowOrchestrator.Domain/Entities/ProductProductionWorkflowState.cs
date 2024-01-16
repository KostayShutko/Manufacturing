using Manufacturing.Common.Domain.Entities;
using MassTransit;

namespace WorkflowOrchestrator.Domain.Entities;

public class ProductProductionWorkflowState : SagaStateMachineInstance, ISagaVersion
{
    public Guid CorrelationId { get; set; }

    public Guid WorkflowId { get; set; }

    public string CurrentState { get; set; }

    public int ReservationStatus { get; set; }

    public int Version { get; set; }

    public int MaterialId { get; set; }

    public int ProductId { get; set; }

    public int ProcessId { get; set; }

    public ProductCode ProductCode { get; set; }
}
