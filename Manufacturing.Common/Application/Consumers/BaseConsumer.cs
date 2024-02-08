using AutoMapper;
using Manufacturing.Common.Application.EventContracts;
using Manufacturing.Common.Application.Factories;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;

namespace Manufacturing.Common.Application.Consumers;

public abstract class BaseConsumer<TMessage, TCommand>
        where TMessage : BaseEvent
        where TCommand : class
{
    private readonly IEventPublisher eventPublisher;
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public BaseConsumer(IEventPublisher eventPublisher, IMediator mediator, IMapper mapper)
    {
        this.eventPublisher = eventPublisher;
        this.mediator = mediator;
        this.mapper = mapper;
    }

    protected async Task<ResponseResultBase> HandleMessage(ConsumeContext<TMessage> context)
    {
        var command = mapper.Map<TCommand>(context.Message);
        var response = await HandleCommand(command);
        await HandleResponseResult(response, context.Message.WorkflowId);
        return response;
    }

    private async Task<ResponseResultBase> HandleCommand(TCommand command)
    {
        try
        {
            var result = await mediator.Send(command);
            if (result is ResponseResultBase responseResult)
            {
                return responseResult;
            }
            return ResponseResult.CreateSuccess(result);
        }
        catch (Exception exception)
        {
            var error = ErrorMessageFactory.CreateErrorMessage(exception);
            return ResponseResult.CreateFail(error);
        }
    }

    private async Task HandleResponseResult(ResponseResultBase response, Guid workflowId)
    {
        if (response.HasError)
        {
            var executionFailedEvent = new ExecutionFailedEvent(workflowId, response.Error);
            await eventPublisher.Publish(executionFailedEvent);
        }
    }
}
