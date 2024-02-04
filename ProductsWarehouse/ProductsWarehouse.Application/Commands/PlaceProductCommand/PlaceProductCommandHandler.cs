using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Products;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Application.Commands.PlaceProductCommand;

public class PlaceProductCommandHandler : BaseCommand<Product>, IRequestHandler<PlaceProductCommand, ResponseResult>
{
    private readonly IEventPublisher eventPublisher;

    public PlaceProductCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
            : base(unitOfWork)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task<ResponseResult> Handle(PlaceProductCommand command, CancellationToken cancellationToken)
    {
        var product = await FindByIdAsync(command.ProductId);

        if (product == null)
        {
            return ResponseResult.CreateFail("Product was not reserved");
        }

        product.SetProductCode(command.ProductCode);
        product.Place();

        await SaveChangesAsync(product);

        await eventPublisher.Publish(new ProductPlacedEvent(command.WorkflowId));

        return ResponseResult.CreateSuccess();
    }
}
