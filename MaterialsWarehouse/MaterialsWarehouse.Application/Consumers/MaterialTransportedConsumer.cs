using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Transportations;
using MassTransit;
using MaterialsWarehouse.Application.Commands.TransportMaterialCommand;
using MediatR;

namespace MaterialsWarehouse.Application.Consumers;

public class MaterialTransportedConsumer : BaseConsumer<MaterialTransportedEvent, TransportMaterialCommand>, IConsumer<MaterialTransportedEvent>
{
    public MaterialTransportedConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<MaterialTransportedEvent> context) => await HandleMessage(context);
}
