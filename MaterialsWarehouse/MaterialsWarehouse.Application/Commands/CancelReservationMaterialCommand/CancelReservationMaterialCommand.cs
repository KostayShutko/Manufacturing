using MediatR;

namespace MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand
{
    public class CancelReservationMaterialCommand : IRequest<int>
    {
        public CancelReservationMaterialCommand(int materialId)
        {
            MaterialId = materialId;
        }

        public int MaterialId { get; }
    }
}
