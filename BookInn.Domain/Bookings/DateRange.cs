namespace BookInn.Domain.Bookings;

public record DateRange
{
    private DateRange()
    {
    }

    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
    
    public int Days => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ApplicationException("Start date cannot be greater than end date");
        }

        return new DateRange()
        {
            Start = start,
            End = end
        };
    }
}