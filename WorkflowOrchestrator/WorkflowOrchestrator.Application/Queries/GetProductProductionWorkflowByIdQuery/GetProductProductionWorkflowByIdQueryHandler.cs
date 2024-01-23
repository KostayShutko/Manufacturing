using AutoMapper;
using Manufacturing.Common.Application.ResponseResults;
using MediatR;
using WorkflowOrchestrator.Application.DTOs;
using WorkflowOrchestrator.Domain.Entities;
using WorkflowOrchestrator.Infrastructure.Database;

namespace WorkflowOrchestrator.Application.Queries.GetProductProductionWorkflowByIdQuery;

public class GetProductProductionWorkflowByIdQueryHandler : IRequestHandler<GetProductProductionWorkflowByIdQuery, ResponseResult<ProductProductionWorkflowDto>>
{
    private readonly IMapper mapper;
    protected readonly WorkflowsContext workflowsContext;

    public GetProductProductionWorkflowByIdQueryHandler(WorkflowsContext workflowsContext, IMapper mapper)
    {
        this.mapper = mapper;
        this.workflowsContext = workflowsContext;
    }

    public async Task<ResponseResult<ProductProductionWorkflowDto>> Handle(GetProductProductionWorkflowByIdQuery query, CancellationToken cancellationToken)
    {
        var workflow = await workflowsContext.Set<ProductProductionWorkflowState>().FindAsync(query.WorkflowId);

        var workflowDto = mapper.Map<ProductProductionWorkflowDto>(workflow);

        return ResponseResult.CreateSuccess(workflowDto);
    }
}
