using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.TransportMaterialCommand
{
    public class TransportMaterialCommandHandler : BaseCommand<Material>, IRequestHandler<TransportMaterialCommand, ResponseResult>
    {
        public TransportMaterialCommandHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<ResponseResult> Handle(TransportMaterialCommand command, CancellationToken cancellationToken)
        {
            var material = await FindByIdAsync(command.MaterialId);

            material.Transport();

            await SaveChangesAsync(material);

            return ResponseResult.CreateSuccess();
        }
    }
}
