using Manufacturing.Common.Application.EventContracts;
using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.EventContracts.Processes;
using Manufacturing.Common.Application.EventContracts.Products;
using Manufacturing.Common.Common.Extensions;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using WorkflowOrchestrator.Domain.Entities;

namespace WorkflowOrchestrator.Application.Workflows.Handlers;

public class ProductProductionFailureHandler : IStateMachineActivity<ProductProductionWorkflowState, ExecutionFailedEvent>
{
    private readonly IEventPublisher eventPublisher;

    public ProductProductionFailureHandler(IEventPublisher eventPublisher)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task Execute(
        BehaviorContext<ProductProductionWorkflowState, ExecutionFailedEvent> context,
        IBehavior<ProductProductionWorkflowState, ExecutionFailedEvent> next)
    {
        if (!context.Saga.MaterialId.IsNew())
        {
            await eventPublisher.Publish(new CancelMaterialReservationCommandEvent(context.Saga.MaterialId, context.Saga.WorkflowId));
        }

        if (!context.Saga.ProductId.IsNew())
        {
            await eventPublisher.Publish(new CancelProductReservationCommandEvent(context.Saga.ProductId, context.Message.WorkflowId));
        }

        if (!context.Saga.ProcessId.IsNew())
        {
            await eventPublisher.Publish(new CancelProcessCommandEvent(context.Saga.ProcessId, context.Message.WorkflowId));
        }

        await next.Execute(context).ConfigureAwait(false);
    }

    public Task Faulted<TException>(
        BehaviorExceptionContext<ProductProductionWorkflowState, ExecutionFailedEvent, TException> context,
        IBehavior<ProductProductionWorkflowState, ExecutionFailedEvent> next)
        where TException : Exception
    {
        return next.Faulted(context);
    }

    public void Probe(ProbeContext context)
    {
        context.CreateScope("compensate");
    }

    public void Accept(StateMachineVisitor visitor)
    {
        visitor.Visit(this);
    }
}
