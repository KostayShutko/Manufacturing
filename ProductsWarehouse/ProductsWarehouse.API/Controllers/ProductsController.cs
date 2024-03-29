﻿using Manufacturing.Common.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsWarehouse.Application.Commands.ReserveProductCommand;
using ProductsWarehouse.Application.Commands.ShipProductCommand;
using ProductsWarehouse.Application.Commands.PlaceProductCommand;
using ProductsWarehouse.Application.Queries.GetAllProductsQuery;

namespace ProductsWarehouse.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    [HttpPut("reserveProduct")]
    public async Task<IActionResult> ReserveProductAsync()
    {
        var result = await mediator.Send(new ReserveProductCommand(Guid.NewGuid()));
        return Ok(result);
    }

    [HttpPut("placeProduct")]
    public async Task<IActionResult> PlaceProductAsync(ProductCode productCode, int productId)
    {
        var result = await mediator.Send(new PlaceProductCommand(Guid.NewGuid(), productCode, productId));
        return Ok(result);
    }

    [HttpPut("shipProduct/{id}")]
    public async Task<IActionResult> ShipProductAsync(int id)
    {
        var result = await mediator.Send(new ShipProductCommand(id));
        return Ok(result);
    }
}
