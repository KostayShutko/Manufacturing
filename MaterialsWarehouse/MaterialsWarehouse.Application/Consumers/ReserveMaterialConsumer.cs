using AutoMapper;
using Manufacturing.Common.Application.EventContracts;
using MassTransit;
using MaterialsWarehouse.Application.Commands.ReserveMaterialCommand;
using MediatR;

namespace MaterialsWarehouse.Application.Consumers
{
    public class ReserveMaterialConsumer : IConsumer<ReserveMaterialCommandEvent>
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ReserveMaterialConsumer(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task Consume(ConsumeContext<ReserveMaterialCommandEvent> context)
        {
            var command = mapper.Map<ReserveMaterialCommand>(context.Message);
            var result = await mediator.Send(command);
        }
    }
}
