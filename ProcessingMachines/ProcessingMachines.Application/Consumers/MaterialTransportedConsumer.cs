using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;
using ProcessingMachines.Application.Commands.CreateProcessCommand;

namespace ProcessingMachines.Application.Consumers;

public  class MaterialTransportedConsumer : BaseConsumer<MaterialTransportedEvent, CreateProcessCommand>, IConsumer<MaterialTransportedEvent>
{
    public MaterialTransportedConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper) : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<MaterialTransportedEvent> context) => await HandleMessage(context);
}
