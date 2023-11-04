using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand
{
    public class CancelReservationMaterialCommand : IRequest<ResponseResult>
    {
        public CancelReservationMaterialCommand(int materialId)
        {
            MaterialId = materialId;
        }

        public int MaterialId { get; }
    }
}
