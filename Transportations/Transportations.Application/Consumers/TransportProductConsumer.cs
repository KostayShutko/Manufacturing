using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Transportations;
using MassTransit;
using MediatR;
using Transportations.Application.Commands.TransportProductCommand;

namespace Transportations.Application.Consumers;

public class TransportProductConsumer : BaseConsumer<TransportProductCommandEvent, TransportProductCommand>, IConsumer<TransportProductCommandEvent>
{
    public TransportProductConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<TransportProductCommandEvent> context) => await HandleMessage(context);
}
