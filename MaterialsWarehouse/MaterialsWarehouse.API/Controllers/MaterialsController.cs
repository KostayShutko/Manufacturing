using MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand;
using MaterialsWarehouse.Application.Commands.DeliverMaterialCommand;
using MaterialsWarehouse.Application.Commands.ReserveMaterialCommand;
using MaterialsWarehouse.Application.Commands.TransportMaterialCommand;
using MaterialsWarehouse.Application.Queries.GetAllMaterialsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsWarehouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialsController : ControllerBase
    {
        private readonly IMediator mediator;

        public MaterialsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> DeliverMaterialAsync()
        {
            var result = await mediator.Send(new DeliverMaterialCommand());
            return Ok(result);
        }

        [HttpPut("reserveMaterial")]
        public async Task<IActionResult> ReserveMaterialAsync()
        {
            var result = await mediator.Send(new ReserveMaterialCommand());
            return Ok(result);
        }

        [HttpPut("transportMaterial/{id}")]
        public async Task<IActionResult> TransportMaterialAsync(int id)
        {
            var result = await mediator.Send(new TransportMaterialCommand(id));
            return Ok(result);
        }

        [HttpPut("cancelReservation/{id}")]
        public async Task<IActionResult> CancelReservationMaterialAsync(int id)
        {
            var result = await mediator.Send(new CancelReservationMaterialCommand(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await mediator.Send(new GetAllMaterialsQuery());
            return Ok(result);
        }
    }
}
