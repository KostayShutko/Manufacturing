using MassTransit;

namespace Manufacturing.Common.Infrastructure.EventBus
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint publisher;

        public EventPublisher(IPublishEndpoint publisher)
        {
            this.publisher = publisher;
        }

        public async Task Publish<TMessage>(TMessage eventMessage)
            => await publisher.Publish(eventMessage);
    }
}
