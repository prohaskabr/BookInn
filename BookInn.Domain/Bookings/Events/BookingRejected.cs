using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Bookings.Events;

public record BookingRejected(Guid BookingId): IDomainEvent;