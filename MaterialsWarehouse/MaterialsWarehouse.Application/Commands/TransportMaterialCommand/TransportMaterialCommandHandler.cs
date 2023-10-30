using Manufacturing.Common.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.TransportMaterialCommand
{
    public class TransportMaterialCommandHandler : IRequestHandler<TransportMaterialCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public TransportMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(TransportMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await unitOfWork.Repository<Material>().FindByIdAsync(command.MaterialId);

            material.Transport();

            unitOfWork.Repository<Material>().Update(material);
            await unitOfWork.SaveChangesAsync();

            return material.Id;
        }
    }
}
