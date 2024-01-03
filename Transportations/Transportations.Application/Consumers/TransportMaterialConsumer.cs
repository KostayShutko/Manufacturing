using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Transportations;
using MassTransit;
using MediatR;
using Transportations.Application.Commands.TransportMaterialCommand;

namespace Transportations.Application.Consumers;

public class TransportMaterialConsumer : BaseConsumer<TransportMaterialCommandEvent, TransportMaterialCommand>, IConsumer<TransportMaterialCommandEvent>
{
    public TransportMaterialConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<TransportMaterialCommandEvent> context) => await HandleMessage(context);
}
