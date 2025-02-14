using BookInn.Application.Abstractions.Messaging;

namespace BookInn.Application.Bookings.ReserveBooking;

public record ReserveBooking(
    Guid AppartmentId,
    Guid UserId,
    DateOnly Start,
    DateOnly End
) : ICommand<Guid>;