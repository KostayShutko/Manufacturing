using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Products;
using MassTransit;
using MediatR;
using ProductsWarehouse.Application.Commands.PlaceProductCommand;

namespace ProductsWarehouse.Application.Consumers;

public class ProductTransportedConsumer : BaseConsumer<ProductTransportedEvent, PlaceProductCommand>, IConsumer<ProductTransportedEvent>
{
    public ProductTransportedConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<ProductTransportedEvent> context) => await HandleMessage(context);
}
