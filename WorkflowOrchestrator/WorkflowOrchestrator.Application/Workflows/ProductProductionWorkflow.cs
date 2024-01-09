using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.EventContracts.Products;
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
        // TODO correlate by workflow Id
        Event(() => MaterialReservedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));
        Event(() => ProductReservedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));
        CompositeEvent(() => ReservationCompletedEvent,
            state => state.ReservationStatus, MaterialReservedEvent, ProductReservedEvent);

        InstanceState(state => state.CurrentState);

        Initially(When(ProductProductionWorkflowInitializationEvent)
            .Then(context => context.Instance.WorkflowId = context.Data.WorkflowId)
            .Publish(context => new ReserveMaterialCommandEvent(context.Instance.CorrelationId))
            .Publish(context => new ReserveProductCommandEvent(context.Instance.CorrelationId))
            .TransitionTo(WorkflowStarted));

        During(WorkflowStarted,
            When(MaterialReservedEvent)
                .Then(context => context.Instance.MaterialId = context.Data.MaterialId),
            When(ProductReservedEvent)
                .Then(context => context.Instance.ProductId = context.Data.ProductId),
            When(ReservationCompletedEvent)
                .TransitionTo(ReservationCompleted));

        SetCompletedWhenFinalized();
    }

    public Event<ProductProductionWorkflowInitializationEvent> ProductProductionWorkflowInitializationEvent { get; set; }

    public Event<MaterialReservedEvent> MaterialReservedEvent { get; set; }

    public Event<ProductReservedEvent> ProductReservedEvent { get; set; }

    public Event ReservationCompletedEvent { get; set; }

    public State WorkflowStarted { get; set; }

    public State ReservationCompleted { get; set; }

    public State MaterialTransported { get; set; }

    public State ProductProduced { get; set; }

    public State ProductTransported { get; set; }

    public State ProductPlaced { get; set; }
}
