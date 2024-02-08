using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.DeliverMaterialCommand;

public class DeliverMaterialCommandHandler : BaseCommand<Material>, IRequestHandler<DeliverMaterialCommand, ResponseResult<int>>
{
    public DeliverMaterialCommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    public async Task<ResponseResult<int>> Handle(DeliverMaterialCommand command, CancellationToken cancellationToken)
    {
        var material = Material.Create();

        var addedMaterial = await SaveChangesAsync(material);

        return ResponseResult.CreateSuccess(addedMaterial.Id);
    }
}
