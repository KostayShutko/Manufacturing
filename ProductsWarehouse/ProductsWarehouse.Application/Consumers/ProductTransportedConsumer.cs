using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;
using ProductsWarehouse.Application.Commands.PlaceProductCommand;

namespace ProductsWarehouse.Application.Consumers;

public class ProductTransportedConsumer : BaseConsumer<ProductTransportedEvent, PlaceProductCommand>, IConsumer<ProductTransportedEvent>
{
    public ProductTransportedConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper) : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<ProductTransportedEvent> context) => await HandleMessage(context);
}
