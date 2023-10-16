using Manufacturing.Common.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.DeliverMaterialCommand
{
    public class DeliverMaterialCommandHandler : IRequestHandler<DeliverMaterialCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeliverMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeliverMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = new Material();

            var addedMaterial = await unitOfWork.Repository<Material>().AddAsync(material);
            await unitOfWork.SaveChangesAsync();

            return addedMaterial.Id;
        }
    }
}
