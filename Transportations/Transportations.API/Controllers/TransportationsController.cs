using Manufacturing.Common.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transportations.Application.Commands.TransportMaterialCommand;
using Transportations.Application.Commands.TransportProductCommand;
using Transportations.Application.Queries.GetAllTransportationsQuery;

namespace Transportations.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransportationsController : ControllerBase
{
    private readonly IMediator mediator;

    public TransportationsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await mediator.Send(new GetAllTransportationsQuery());
        return Ok(result);
    }

    [HttpPut("transportMaterial")]
    public async Task<IActionResult> TransportMaterialAsync(int materialId)
    {
        var result = await mediator.Send(new TransportMaterialCommand(Guid.NewGuid(), materialId));
        return Ok(result);
    }

    [HttpPut("transportProduct")]
    public async Task<IActionResult> TransportProductAsync(int productId, ProductCode productCode)
    {
        var result = await mediator.Send(new TransportProductCommand(Guid.NewGuid(), productId, productCode));
        return Ok(result);
    }
}
