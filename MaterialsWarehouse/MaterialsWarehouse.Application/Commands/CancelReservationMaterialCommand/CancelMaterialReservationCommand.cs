using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand;

public class CancelMaterialReservationCommand : IRequest<ResponseResult>
{
    public CancelMaterialReservationCommand(int materialId)
    {
        MaterialId = materialId;
    }

    public int MaterialId { get; }
}
