using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using Transportations.Domain.Entities;

namespace Transportations.Application.Commands.TransportMaterialCommand;

public class TransportMaterialCommandHandler : BaseCommand<Transportation>, IRequestHandler<TransportMaterialCommand, ResponseResult>
{
    private readonly IEventPublisher eventPublisher;

    public TransportMaterialCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
            : base(unitOfWork)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task<ResponseResult> Handle(TransportMaterialCommand command, CancellationToken cancellationToken)
    {
        var transportation = Transportation.Create(Position.MaterialsWarehouse, Position.ProcessingMachines, command.WorkflowId);

        await SaveChangesAsync(transportation);

        await eventPublisher.Publish(new MaterialTransportedEvent(command.MaterialId, command.WorkflowId));

        return ResponseResult.CreateSuccess();
    }
}
