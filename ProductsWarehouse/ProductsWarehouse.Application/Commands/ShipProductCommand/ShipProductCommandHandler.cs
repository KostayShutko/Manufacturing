using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Application.Commands.ShipProductCommand;

public class ShipProductCommandHandler : BaseCommand<Product>, IRequestHandler<ShipProductCommand, ResponseResult>
{
    public ShipProductCommandHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
    {
    }

    public async Task<ResponseResult> Handle(ShipProductCommand command, CancellationToken cancellationToken)
    {
        var product = await FindByIdAsync(command.ProductId);

        product.Ship();

        await SaveChangesAsync(product);

        return ResponseResult.CreateSuccess();
    }
}
