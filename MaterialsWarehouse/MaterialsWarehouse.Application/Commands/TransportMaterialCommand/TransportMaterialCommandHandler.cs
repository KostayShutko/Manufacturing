using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.TransportMaterialCommand
{
    public class TransportMaterialCommandHandler : BaseCommand<Material>, IRequestHandler<TransportMaterialCommand, ResponseResult>
    {
        private readonly IEventPublisher eventPublisher;

        public TransportMaterialCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
            : base(unitOfWork)
        {
            this.eventPublisher = eventPublisher;
        }

        public async Task<ResponseResult> Handle(TransportMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await FindByIdAsync(command.MaterialId);

            material.Transport();

            await SaveChangesAsync(material);

            await eventPublisher.Publish(new MaterialTransportedEvent(material.Id));

            return ResponseResult.CreateSuccess();
        }
    }
}
