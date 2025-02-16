using BookInn.Application.Abstractions.Messaging;

namespace BookInn.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
