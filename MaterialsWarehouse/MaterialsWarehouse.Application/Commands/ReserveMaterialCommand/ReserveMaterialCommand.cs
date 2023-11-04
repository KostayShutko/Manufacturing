using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace MaterialsWarehouse.Application.Commands.ReserveMaterialCommand
{
    public class ReserveMaterialCommand : IRequest<ResponseResult<int>>
    {
    }
}
