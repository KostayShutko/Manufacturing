using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Products;
using MassTransit;
using MediatR;
using ProductsWarehouse.Application.Commands.ReserveProductCommand;

namespace ProductsWarehouse.Application.Consumers;

public class ReserveProductConsumer : BaseConsumer<ReserveProductCommandEvent, ReserveProductCommand>, IConsumer<ReserveProductCommandEvent>
{
    public ReserveProductConsumer(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<ReserveProductCommandEvent> context) => await HandleMessage(context);
}
