using AutoMapper;
using Manufacturing.Common.Application.Consumers;
using Manufacturing.Common.Application.EventContracts.Materials;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MaterialsWarehouse.Application.Commands.CancelReservationMaterialCommand;
using MediatR;

namespace MaterialsWarehouse.Application.Consumers;

public class CancelMaterialReservationConsumer : 
    BaseConsumer<CancelMaterialReservationCommandEvent, CancelMaterialReservationCommand>, 
    IConsumer<CancelMaterialReservationCommandEvent>
{
    public CancelMaterialReservationConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper) 
        : base(eventPublisher, mediator, mapper)
    {
    }

    public async Task Consume(ConsumeContext<CancelMaterialReservationCommandEvent> context) => await HandleMessage(context);
}
