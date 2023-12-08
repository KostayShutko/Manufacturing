namespace Manufacturing.Common.Infrastructure.EventBus
{
    public interface IEventPublisher
    {
        Task Publish<TMessage>(TMessage eventMessage);
    }
}
