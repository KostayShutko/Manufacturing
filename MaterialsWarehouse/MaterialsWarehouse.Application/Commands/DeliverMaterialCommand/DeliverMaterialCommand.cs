using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.DeliverMaterialCommand;

public class DeliverMaterialCommand : IRequest<ResponseResult<int>>
{
}
