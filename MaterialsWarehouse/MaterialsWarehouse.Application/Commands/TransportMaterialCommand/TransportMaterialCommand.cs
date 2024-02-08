using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.TransportMaterialCommand;

public class TransportMaterialCommand : IRequest<ResponseResult>
{
    public TransportMaterialCommand(int materialId)
    {
        MaterialId = materialId;
    }

    public int MaterialId { get; }
}
