using Manufacturing.Common.Application.ResponseResults;
using MediatR;
using WorkflowOrchestrator.Application.DTOs;

namespace WorkflowOrchestrator.Application.Queries.GetProductProductionWorkflowByIdQuery;

public class GetProductProductionWorkflowByIdQuery : IRequest<ResponseResult<ProductProductionWorkflowDto>>
{
    public GetProductProductionWorkflowByIdQuery(Guid workflowId)
    {
        WorkflowId = workflowId;
    }

    public Guid WorkflowId { get; }
}
