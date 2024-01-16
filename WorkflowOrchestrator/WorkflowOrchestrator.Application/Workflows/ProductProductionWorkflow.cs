using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.EventContracts.Processes;
using Manufacturing.Common.Application.EventContracts.Products;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Manufacturing.Common.Application.EventContracts.Workflows;
using MassTransit;
using WorkflowOrchestrator.Domain.Entities;

namespace WorkflowOrchestrator.Application.Workflows;

public class ProductProductionWorkflow : MassTransitStateMachine<ProductProductionWorkflowState>
{
    public ProductProductionWorkflow()
    {
        DeclairEventsStep();
        WorkflowInitializationStep();
        ReservationStep();
        MaterialTransportationStep();
        ProcessingStep();
        ProductTransportationStep();
        SetCompletedWhenFinalized();
    }

    private void DeclairEventsStep()
    {
        Event(() => ProductProductionWorkflowInitializationEvent,
            workflowEvent => workflowEvent.CorrelateById(context => context.Message.WorkflowId).SelectId(c => c.Message.WorkflowId));
        // TODO correlate by workflow Id
        Event(() => MaterialReservedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));
        Event(() => ProductReservedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));
        Event(() => MaterialTransportedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));
        Event(() => ProductTransportedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));
        Event(() => ProductProducedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));
        Event(() => ProcessCreatedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));
        Event(() => ProductPlacedEvent, workflowEvent => workflowEvent.CorrelateById(c => c.Message.WorkflowId));

        CompositeEvent(() => ReservationCompletedEvent,
            state => state.ReservationStatus, MaterialReservedEvent, ProductReservedEvent);

        InstanceState(state => state.CurrentState);
    }

    private void WorkflowInitializationStep()
    {
        Initially(When(ProductProductionWorkflowInitializationEvent)
            .Then(context =>
            {
                context.Instance.ProductCode = context.Data.ProductCode;
                context.Instance.WorkflowId = context.Data.WorkflowId;
            })
            .Publish(context => new ReserveMaterialCommandEvent(context.Instance.CorrelationId))
            .Publish(context => new ReserveProductCommandEvent(context.Instance.CorrelationId))
            .TransitionTo(WorkflowStartedState));
    }

    private void ReservationStep()
    {
        During(WorkflowStartedState,
            When(MaterialReservedEvent)
                .Then(context => context.Instance.MaterialId = context.Data.MaterialId),
            When(ProductReservedEvent)
                .Then(context => context.Instance.ProductId = context.Data.ProductId),
            When(ReservationCompletedEvent)
                .TransitionTo(ReservationCompletedState));
    }

    private void MaterialTransportationStep()
    {
        WhenEnter(ReservationCompletedState, binder => binder
            .Publish(context => new TransportMaterialCommandEvent(context.Instance.MaterialId, context.Instance.CorrelationId))
            .TransitionTo(MaterialInTransportationState));

        During(MaterialInTransportationState,
            When(MaterialTransportedEvent)
                .TransitionTo(MaterialTransportedState));
    }

    private void ProcessingStep()
    {
        During(MaterialTransportedState,
            When(ProcessCreatedEvent)
                .Then(context => context.Instance.ProcessId = context.Data.ProcessId)
                .TransitionTo(ProcessCreatedState));

        WhenEnter(ProcessCreatedState, binder => binder
            .Publish(context => new StartProcessingCommandEvent(context.Instance.ProcessId, context.Instance.ProductCode, context.Instance.CorrelationId))
            .TransitionTo(ProcessStartedState));

        During(ProcessStartedState,
            When(ProductProducedEvent)
                .TransitionTo(ProductProducedState));
    }

    private void ProductTransportationStep()
    {
        WhenEnter(ProductProducedState, binder => binder
            .Publish(context => new TransportProductCommandEvent(context.Instance.ProductId, context.Instance.ProductCode, context.Instance.CorrelationId))
            .TransitionTo(ProductInTransportationState));

        During(ProductInTransportationState,
            When(ProductTransportedEvent)
                .TransitionTo(ProductTransportedState));

        During(ProductTransportedState,
            When(ProductPlacedEvent)
                .TransitionTo(ProductPlacedState));
    }

    public Event<ProductProductionWorkflowInitializationEvent> ProductProductionWorkflowInitializationEvent { get; set; }

    public Event<MaterialReservedEvent> MaterialReservedEvent { get; set; }

    public Event<ProductReservedEvent> ProductReservedEvent { get; set; }

    public Event<MaterialTransportedEvent> MaterialTransportedEvent { get; set; }

    public Event<ProductTransportedEvent> ProductTransportedEvent { get; set; }

    public Event<ProcessCreatedEvent> ProcessCreatedEvent { get; set; }

    public Event<ProductProducedEvent> ProductProducedEvent { get; set; }

    public Event<ProductPlacedEvent> ProductPlacedEvent { get; set; }

    public Event ReservationCompletedEvent { get; set; }

    public State WorkflowStartedState { get; set; }

    public State ReservationCompletedState { get; set; }

    public State MaterialInTransportationState { get; set; }

    public State MaterialTransportedState { get; set; }

    public State ProcessCreatedState { get; set; }

    public State ProcessStartedState { get; set; }

    public State ProductProducedState { get; set; }

    public State ProductTransportedState { get; set; }

    public State ProductInTransportationState { get; set; }

    public State ProductPlacedState { get; set; }
}
