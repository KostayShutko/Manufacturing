using Manufacturing.Common.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand
{
    public class CancelReservationMaterialCommandHandler : IRequestHandler<CancelReservationMaterialCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public CancelReservationMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CancelReservationMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await unitOfWork.Repository<Material>().FindByIdAsync(command.MaterialId);

            material.CancelReservation();

            unitOfWork.Repository<Material>().Update(material);
            await unitOfWork.SaveChangesAsync();

            return material.Id;
        }
    }
}
