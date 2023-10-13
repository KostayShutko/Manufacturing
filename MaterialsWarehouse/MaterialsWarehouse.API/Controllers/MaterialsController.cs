using MaterialsWarehouse.Application.Commands.DeliverMaterialCommand;
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
    }
}
