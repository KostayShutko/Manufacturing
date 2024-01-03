using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using Transportations.Domain.Entities;

namespace Transportations.Application.Commands.TransportProductCommand;

public class TransportProductCommandHandler : BaseCommand<Transportation>, IRequestHandler<TransportProductCommand, ResponseResult>
{
    private readonly IEventPublisher eventPublisher;

    public TransportProductCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
            : base(unitOfWork)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task<ResponseResult> Handle(TransportProductCommand command, CancellationToken cancellationToken)
    {
        var transportation = Transportation.Create(Position.ProcessingMachines, Position.ProductsWarehouse, command.WorkflowId);

        await SaveChangesAsync(transportation);

        await eventPublisher.Publish(new ProductTransportedEvent(command.ProductCode, command.WorkflowId));

        return ResponseResult.CreateSuccess();
    }
}
