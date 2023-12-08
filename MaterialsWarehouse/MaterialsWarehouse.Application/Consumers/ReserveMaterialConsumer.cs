using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts;
using MassTransit;
using MediatR;

namespace MaterialsWarehouse.Application.Consumers
{
    public class ReserveMaterialConsumer : BaseConsumer<ReserveMaterialCommandEvent>, IConsumer<ReserveMaterialCommandEvent>
    {
        public ReserveMaterialConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        public async Task Consume(ConsumeContext<ReserveMaterialCommandEvent> context)
        {
            var result = HandleMessage(context);
        }
    }
}
