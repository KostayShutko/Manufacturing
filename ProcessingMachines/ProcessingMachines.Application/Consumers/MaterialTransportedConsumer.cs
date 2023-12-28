using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Materials;
using MassTransit;
using MediatR;
using ProcessingMachines.Application.Commands.CreateProcessCommand;

namespace ProcessingMachines.Application.Consumers;

public  class MaterialTransportedConsumer : BaseConsumer<MaterialTransportedEvent, CreateProcessCommand>, IConsumer<MaterialTransportedEvent>
{
    public MaterialTransportedConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<MaterialTransportedEvent> context) => await HandleMessage(context);
}
