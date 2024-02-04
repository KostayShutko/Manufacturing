using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace ProductsWarehouse.Application.Commands.CancelProductReservationCommand;

public class CancelProductReservationCommand : IRequest<ResponseResult>
{
    public CancelProductReservationCommand(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}