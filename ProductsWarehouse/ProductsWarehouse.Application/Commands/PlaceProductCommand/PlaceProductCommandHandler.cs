using Manufacturing.Common.Application.Commands;
using Manufacturing.Common.Application.EventContracts.Products;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Application.Specifications;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var specification = new GetByWorkflowIdSpecification<Product>(command.WorkflowId);
        var product = await FindBySpecification(specification).FirstOrDefaultAsync();

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
