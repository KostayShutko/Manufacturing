using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Application.EventContracts.Processes;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;
using ProcessingMachines.Application.Commands.CreateProcessCommand;

namespace ProcessingMachines.Application.Consumers;

public  class MaterialTransportedConsumer : BaseConsumer<MaterialTransportedEvent, CreateProcessCommand>, IConsumer<MaterialTransportedEvent>
{
    private readonly IEventPublisher eventPublisher;

    public MaterialTransportedConsumer(IMediator mediator, IMapper mapper, IEventPublisher eventPublisher) : base(mediator, mapper)
    {
        this.eventPublisher = eventPublisher;
    }

    public async Task Consume(ConsumeContext<MaterialTransportedEvent> context)
    {
        var result = await HandleMessage(context);

        if (result.IsSuccessfull && result is ResponseResult<int> responseResult)
        {
            var processId = responseResult.Data;
            await eventPublisher.Publish(new ProcessCreatedEvent(processId));
        }
        else
        {
            await eventPublisher.Publish(new ProcessCreationFailedEvent());
        }
    }
}
