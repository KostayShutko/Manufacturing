using MassTransit;

namespace WorkflowOrchestrator.Application.Workflows.Extensions;

public static class WorkflowExtensions
{
    public static EventActivityBinder<TInstance, TData> HandleBy<TInstance, TData>(
        this EventActivityBinder<TInstance, TData> binder,
        Func<IStateMachineActivitySelector<TInstance, TData>, EventActivityBinder<TInstance, TData>> configure)
        where TInstance : class, SagaStateMachineInstance
        where TData : class

    {
        return binder.Activity(configure);
    }
}