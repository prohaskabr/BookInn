namespace BookInn.Application.Abstractions.Clock;

public class DateTimeProvider : IDateTimeProvider
{ public DateTime UtcNow => DateTime.UtcNow;
}