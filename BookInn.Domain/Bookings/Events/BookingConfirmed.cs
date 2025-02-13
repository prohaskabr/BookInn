using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Bookings.Events;

public record BookingConfirmed(Guid BookingId): IDomainEvent;