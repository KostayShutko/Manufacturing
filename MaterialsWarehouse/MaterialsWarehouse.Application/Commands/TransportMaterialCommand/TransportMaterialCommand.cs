using MediatR;

namespace MaterialsWarehouse.Application.Commands.TransportMaterialCommand
{
    public class TransportMaterialCommand : IRequest<int>
    {
        public TransportMaterialCommand(int materialId)
        {
            MaterialId = materialId;
        }

        public int MaterialId { get; }
    }
}
