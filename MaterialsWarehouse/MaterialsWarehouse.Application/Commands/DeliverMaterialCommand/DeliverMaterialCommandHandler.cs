using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.DeliverMaterialCommand
{
    public class DeliverMaterialCommandHandler : IRequestHandler<DeliverMaterialCommand, ResponseResult<int>>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeliverMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseResult<int>> Handle(DeliverMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = Material.Create();

            var addedMaterial = await unitOfWork.Repository<Material>().AddAsync(material);
            await unitOfWork.SaveChangesAsync();

            return ResponseResult.CreateSuccess(addedMaterial.Id);
        }
    }
}
