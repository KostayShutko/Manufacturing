using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Application.Commands.CancelProductReservationCommand;

public class CancelProductReservationCommandHandler : BaseCommand<Product>, IRequestHandler<CancelProductReservationCommand, ResponseResult>
{
    public CancelProductReservationCommandHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
    {
    }

    public async Task<ResponseResult> Handle(CancelProductReservationCommand command, CancellationToken cancellationToken)
    {
        var product = await FindByIdAsync(command.ProductId);

        product.CancelReservation();

        await SaveChangesAsync(product);

        return ResponseResult.CreateSuccess();
    }
}
