using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Transportations;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;
using Transportations.Application.Commands.TransportProductCommand;

namespace Transportations.Application.Consumers;

public class TransportProductConsumer : BaseConsumer<TransportProductCommandEvent, TransportProductCommand>, IConsumer<TransportProductCommandEvent>
{
    public TransportProductConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper) : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<TransportProductCommandEvent> context) => await HandleMessage(context);
}
