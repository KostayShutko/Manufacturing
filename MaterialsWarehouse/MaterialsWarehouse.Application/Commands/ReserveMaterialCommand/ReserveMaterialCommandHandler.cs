using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Application.Specifications;
using MaterialsWarehouse.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaterialsWarehouse.Application.Commands.ReserveMaterialCommand;

public class ReserveMaterialCommandHandler : BaseCommand<Material>, IRequestHandler<ReserveMaterialCommand, ResponseResult<int>>
{
    private readonly IEventPublisher eventPublisher;

    public ReserveMaterialCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        :base(unitOfWork)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task<ResponseResult<int>> Handle(ReserveMaterialCommand command, CancellationToken cancellationToken)
    {
        var material = await FindBySpecification(new MaterialToReserveSpecification()).FirstOrDefaultAsync();

        if (material == null)
        {
            return ResponseResult<int>.CreateFail("No material to reserve");
        }

        material.Reserve();
        material.AssignWorkflow(command.WorkflowId);

        await SaveChangesAsync(material);

        await eventPublisher.Publish(new MaterialReservedEvent(material.Id, material.WorkflowId));

        return ResponseResult.CreateSuccess(material.Id);
    }
}
