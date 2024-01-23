using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MaterialsWarehouse.Application.Commands.ReserveMaterialCommand;
using MediatR;

namespace MaterialsWarehouse.Application.Consumers
{
    public class ReserveMaterialConsumer : BaseConsumer<ReserveMaterialCommandEvent, ReserveMaterialCommand>, IConsumer<ReserveMaterialCommandEvent>
    {
        public ReserveMaterialConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper) : base(eventPublisher, mediator, mapper) 
        {
        }

        public async Task Consume(ConsumeContext<ReserveMaterialCommandEvent> context) => await HandleMessage(context);
    }
}
