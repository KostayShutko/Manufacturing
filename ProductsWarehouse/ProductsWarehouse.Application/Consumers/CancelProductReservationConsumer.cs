using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Products;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;
using ProductsWarehouse.Application.Commands.CancelProductReservationCommand;

namespace ProductsWarehouse.Application.Consumers;

public class CancelProductReservationConsumer :
    BaseConsumer<CancelProductReservationCommandEvent, CancelProductReservationCommand>,
    IConsumer<CancelProductReservationCommandEvent>
{
    public CancelProductReservationConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper)
        : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<CancelProductReservationCommandEvent> context) => await HandleMessage(context);
}