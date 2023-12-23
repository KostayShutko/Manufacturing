using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Processes;
using MassTransit;
using MediatR;
using ProcessingMachines.Application.Commands.StartProcessCommand;

namespace ProcessingMachines.Application.Consumers;

public class ProcessCreatedConsumer : BaseConsumer<ProcessCreatedEvent, StartProcessCommand>, IConsumer<ProcessCreatedEvent>
{
    public ProcessCreatedConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper) {}

    public async Task Consume(ConsumeContext<ProcessCreatedEvent> context)
    {
        await HandleMessage(context);
    }
}
