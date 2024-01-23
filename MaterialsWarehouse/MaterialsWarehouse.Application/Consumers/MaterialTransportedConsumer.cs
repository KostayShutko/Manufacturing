using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MaterialsWarehouse.Application.Commands.TransportMaterialCommand;
using MediatR;

namespace MaterialsWarehouse.Application.Consumers;

public class MaterialTransportedConsumer : BaseConsumer<MaterialTransportedEvent, TransportMaterialCommand>, IConsumer<MaterialTransportedEvent>
{
    public MaterialTransportedConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper) : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<MaterialTransportedEvent> context) => await HandleMessage(context);
}
