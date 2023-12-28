using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Processes;
using MassTransit;
using MediatR;
using ProcessingMachines.Application.Commands.StartProcessCommand;

namespace ProcessingMachines.Application.Consumers;

public class StartProcessConsumer : BaseConsumer<StartProcessCommandEvent, StartProcessCommand>, IConsumer<StartProcessCommandEvent>
{
    public StartProcessConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<StartProcessCommandEvent> context) => await HandleMessage(context);
}
