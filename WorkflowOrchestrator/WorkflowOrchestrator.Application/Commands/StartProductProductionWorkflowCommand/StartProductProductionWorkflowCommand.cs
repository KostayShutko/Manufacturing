using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Entities;
using MediatR;
using WorkflowOrchestrator.Application.DTOs;

namespace WorkflowOrchestrator.Application.Commands.StartProductProductionWorkflowCommand;

public class StartProductProductionWorkflowCommand : IRequest<ResponseResult<WorkflowInitializationDto>>
{
    public StartProductProductionWorkflowCommand(ProductCode productCode)
    {
        ProductCode = productCode;
    }

    public ProductCode ProductCode { get; }
}