using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Processes;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;
using ProcessingMachines.Application.Commands.CancelProcessCommand;

namespace ProcessingMachines.Application.Consumers;

public class CancelProcessConsumer :
    BaseConsumer<CancelProcessCommandEvent, CancelProcessCommand>,
    IConsumer<CancelProcessCommandEvent>
{
    public CancelProcessConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper)
        : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<CancelProcessCommandEvent> context) => await HandleMessage(context);
}