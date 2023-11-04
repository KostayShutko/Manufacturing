using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.TransportMaterialCommand
{
    public class TransportMaterialCommandHandler : IRequestHandler<TransportMaterialCommand, ResponseResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public TransportMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseResult> Handle(TransportMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await unitOfWork.Repository<Material>().FindByIdAsync(command.MaterialId);

            material.Transport();

            unitOfWork.Repository<Material>().Update(material);
            await unitOfWork.SaveChangesAsync();

            return ResponseResult.CreateSuccess();
        }
    }
}
