namespace Manufacturing.Common.Infrastructure.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDateTime() => DateTime.UtcNow;
    }
}
