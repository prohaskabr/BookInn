using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Bookings.Events;

public record BookingCompleted(Guid BookingId): IDomainEvent;