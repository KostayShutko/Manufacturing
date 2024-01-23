using AutoMapper;
using Manufacturing.Common.Application.EventContracts;
using Manufacturing.Common.Application.Factories;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Infrastructure.EventBus;
using MassTransit;
using MediatR;

namespace Manufacturing.Common.Application.Consumers
{
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
            var response = await HandleMessage(context.Message);
            await PublishExecutionResult(context.Message.WorkflowId, response);
            return response;
        }

        private async Task<ResponseResultBase> HandleMessage(TMessage message)
        {
            try
            {
                var command = mapper.Map<TCommand>(message);
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

        private async Task PublishExecutionResult(Guid workflowId, ResponseResultBase response)
        {
            if (response.HasError)
            {
                var executionFailedEvent = new ExecutionFailedEvent(workflowId, response.Error);
                await eventPublisher.Publish(executionFailedEvent);
            }
        }
    }
}
