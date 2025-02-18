using BookInn.Application.Abstractions.Clock;

namespace BookInn.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}