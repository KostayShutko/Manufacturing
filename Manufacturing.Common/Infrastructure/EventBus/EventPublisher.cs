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
        {
            using var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await publisher.Publish(eventMessage, cancellationToken.Token);
        }
    }
}
