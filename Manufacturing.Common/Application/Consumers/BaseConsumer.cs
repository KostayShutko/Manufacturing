using AutoMapper;
using Manufacturing.Common.Application.Factories;
using Manufacturing.Common.Application.ResponseResults;
using MassTransit;
using MediatR;

namespace Manufacturing.Common.Application.Consumers
{
    public abstract class BaseConsumer<TMessage>
        where TMessage : class
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public BaseConsumer(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        protected async Task<ResponseResultBase> HandleMessage(ConsumeContext<TMessage> context)
        {
            try
            {
                var command = mapper.Map<TMessage>(context.Message);
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
    }
}
