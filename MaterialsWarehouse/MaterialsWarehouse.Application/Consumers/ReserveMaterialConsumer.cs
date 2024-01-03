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
        private readonly IEventPublisher eventPublisher;

        public ReserveMaterialConsumer(IMediator mediator, IMapper mapper, IEventPublisher eventPublisher) : base(mediator, mapper) 
        {
            this.eventPublisher = eventPublisher;
        }

        public async Task Consume(ConsumeContext<ReserveMaterialCommandEvent> context)
        {
            var result = await HandleMessage(context);

            if (!result.IsSuccessfull)
            {
                await eventPublisher.Publish(new MaterialReservationFailedEvent(context.Message.WorkflowId));
            }
        }
    }
}
