using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.EventContracts.Workflows;
using MassTransit;
using WorkflowOrchestrator.Domain.Entities;

namespace WorkflowOrchestrator.Application.Workflows;

public class ProductProductionWorkflow : MassTransitStateMachine<ProductProductionWorkflowState>
{
    public ProductProductionWorkflow()
    {
        Event(() => ProductProductionWorkflowInitializationEvent,
            workflowEvent => workflowEvent.CorrelateById(context => context.Message.WorkflowId).SelectId(c => c.Message.WorkflowId));
        Event(() => MaterialReservedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));

        InstanceState(state => state.CurrentState);

        Initially(When(ProductProductionWorkflowInitializationEvent)
            .Publish(context => new ReserveMaterialCommandEvent(context.Instance.CorrelationId))
            .TransitionTo(WorkflowStarted));

        During(WorkflowStarted, When(MaterialReservedEvent)
            .TransitionTo(ReservationCompleted));

        SetCompletedWhenFinalized();
    }

    public Event<ProductProductionWorkflowInitializationEvent> ProductProductionWorkflowInitializationEvent { get; set; }

    public Event<MaterialReservedEvent> MaterialReservedEvent { get; set; }

    public State WorkflowStarted { get; set; }

    public State ReservationCompleted { get; set; }
}
