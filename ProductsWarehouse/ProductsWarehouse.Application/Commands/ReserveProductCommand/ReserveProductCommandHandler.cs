using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Products;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Application.Commands.ReserveProductCommand;

public class ReserveProductCommandHandler : BaseCommand<Product>, IRequestHandler<ReserveProductCommand, ResponseResult<int>>
{
    private readonly IEventPublisher eventPublisher;

    public ReserveProductCommandHandler(IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
            : base(unitOfWork)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task<ResponseResult<int>> Handle(ReserveProductCommand command, CancellationToken cancellationToken)
    {
        var product = Product.Create(command.WorkflowId);

        product.Reserve();

        var addedProduct = await SaveChangesAsync(product);

        await eventPublisher.Publish(new ProductReservedEvent(command.WorkflowId));

        return ResponseResult.CreateSuccess(addedProduct.Id);
    }
}
