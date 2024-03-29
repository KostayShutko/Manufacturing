﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProcessingMachines.API.Requests;
using ProcessingMachines.Application.Commands.CreateProcessCommand;
using ProcessingMachines.Application.Commands.StartProcessCommand;
using ProcessingMachines.Application.Queries.GetAllProcessesQuery;

namespace ProcessingMachines.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcessesController : ControllerBase
{
    private readonly IMediator mediator;

    public ProcessesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await mediator.Send(new GetAllProcessesQuery());
        return Ok(result);
    }

    [HttpPut("createProcess/{materialId}")]
    public async Task<IActionResult> CreateProcessAsync(int materialId)
    {
        var result = await mediator.Send(new CreateProcessCommand(materialId, Guid.NewGuid()));
        return Ok(result);
    }

    [HttpPut("startProcess/{id}")]
    public async Task<IActionResult> StartProcessAsync([FromRoute] int id, [FromBody] StartProcessRequest request)
    {
        var result = await mediator.Send(new StartProcessCommand(id, request.ProductCode));
        return Ok(result);
    }
}
