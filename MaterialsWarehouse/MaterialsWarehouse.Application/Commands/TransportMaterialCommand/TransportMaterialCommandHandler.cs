using Manufacturing.Common.Application.EventContracts;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.TransportMaterialCommand
{
    public class TransportMaterialCommandHandler : IRequestHandler<TransportMaterialCommand, ResponseResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEventPublisher eventPublisher;

        public TransportMaterialCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            this.unitOfWork = unitOfWork;
            this.eventPublisher = eventPublisher;
        }

        public async Task<ResponseResult> Handle(TransportMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await unitOfWork.Repository<Material>().FindByIdAsync(command.MaterialId);

            material.Transport();

            unitOfWork.Repository<Material>().Update(material);
            await unitOfWork.SaveChangesAsync();

            await eventPublisher.Publish(new ReserveMaterialCommandEvent());

            return ResponseResult.CreateSuccess();
        }
    }
}
