using Manufacturing.Common.Application.ResponseResults;
using MediatR;

namespace ProductsWarehouse.Application.Commands.ShipProductCommand;

public class ShipProductCommand : IRequest<ResponseResult>
{
    public ShipProductCommand(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}
