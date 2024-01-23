using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Processes;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;
using ProcessingMachines.Application.Commands.StartProcessCommand;

namespace ProcessingMachines.Application.Consumers;

public class StartProcessConsumer : BaseConsumer<StartProcessingCommandEvent, StartProcessCommand>, IConsumer<StartProcessingCommandEvent>
{
    public StartProcessConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper) : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<StartProcessingCommandEvent> context) => await HandleMessage(context);
}
