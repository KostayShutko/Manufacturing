using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Products;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;
using ProductsWarehouse.Application.Commands.ReserveProductCommand;

namespace ProductsWarehouse.Application.Consumers;

public class ReserveProductConsumer : BaseConsumer<ReserveProductCommandEvent, ReserveProductCommand>, IConsumer<ReserveProductCommandEvent>
{
    public ReserveProductConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper) : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<ReserveProductCommandEvent> context) => await HandleMessage(context);
}
