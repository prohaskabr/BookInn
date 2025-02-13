using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Bookings;

public static class BookingErrors
{
    public static Error NotFound = new("Booking.Found","The booking was not found");
    public static Error Overlap = new("Booking.Overlap","The booking is overlapping with an existing booking");
    public static Error NotReserved = new("Booking.NotReserved","The booking is not pending");
    public static Error NotConfirmed= new("Booking.NotConfirmed","The booking is not confirmed");
    public static Error AlreadyStarted= new("Booking.AlreadyStarted","The booking has already been started");
}