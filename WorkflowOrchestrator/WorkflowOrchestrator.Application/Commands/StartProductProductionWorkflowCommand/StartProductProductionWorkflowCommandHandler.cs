using Manufacturing.Common.Application.EventContracts.Workflows;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using MediatR;
using WorkflowOrchestrator.Application.DTOs;

namespace WorkflowOrchestrator.Application.Commands.StartProductProductionWorkflowCommand;

public class StartProductProductionWorkflowCommandHandler : IRequestHandler<StartProductProductionWorkflowCommand, ResponseResult<WorkflowInitializationDto>>
{
    private readonly IEventPublisher eventPublisher;

    public StartProductProductionWorkflowCommandHandler(IEventPublisher eventPublisher)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task<ResponseResult<WorkflowInitializationDto>> Handle(StartProductProductionWorkflowCommand command, CancellationToken cancellationToken)
    {
        var workflowId = Guid.NewGuid();
        var workflowEvent = new ProductProductionWorkflowInitializationEvent(command.ProductCode, workflowId);

        await eventPublisher.Publish(workflowEvent);

        var response = new WorkflowInitializationDto
        {
            WorkflowId = workflowId
        };
        return ResponseResult.CreateSuccess(response);
    }
}