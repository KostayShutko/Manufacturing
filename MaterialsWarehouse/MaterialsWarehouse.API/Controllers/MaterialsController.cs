using MaterialsWarehouse.Application.Commands.DeliverMaterialCommand;
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
        public async Task<IActionResult> AddStudentAsync()
        {
            var result = await mediator.Send(new DeliverMaterialCommand());
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
