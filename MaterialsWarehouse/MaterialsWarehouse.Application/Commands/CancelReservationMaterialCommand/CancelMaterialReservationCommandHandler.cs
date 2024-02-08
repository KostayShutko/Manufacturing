using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Domain.Entities;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand;

public class CancelMaterialReservationCommandHandler : BaseCommand<Material>, IRequestHandler<CancelMaterialReservationCommand, ResponseResult>
{
    public CancelMaterialReservationCommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    public async Task<ResponseResult> Handle(CancelMaterialReservationCommand command, CancellationToken cancellationToken)
    {
        var material = await FindByIdAsync(command.MaterialId);

        material.CancelReservation();

        await SaveChangesAsync(material);

        return ResponseResult.CreateSuccess();
    }
}
