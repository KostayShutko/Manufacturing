using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkflowOrchestrator.API.Requests;
using WorkflowOrchestrator.Application.Commands.StartProductProductionWorkflowCommand;
using WorkflowOrchestrator.Application.Queries.GetProductProductionWorkflowByIdQuery;

namespace WorkflowOrchestrator.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkflowsController : ControllerBase
{
    private readonly IMediator mediator;

    public WorkflowsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("products")]
    public async Task<IActionResult> StartProductProductionWorkflowAsync([FromBody] StartProductProductionWorkflowRequest request)
    {
        var command = new StartProductProductionWorkflowCommand(request.ProductCode);
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetProductProductionWorkflowByIdAsync(Guid id)
    {
        var query = new GetProductProductionWorkflowByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}