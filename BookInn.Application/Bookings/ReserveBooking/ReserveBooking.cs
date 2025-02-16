using BookInn.Application.Abstractions.Messaging;

namespace BookInn.Application.Bookings.ReserveBooking;

public record ReserveBooking(
    Guid ApartmentId,
    Guid UserId,
    DateOnly Start,
    DateOnly End
) : ICommand<Guid>;