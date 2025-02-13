using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Bookings.Events;

public record BookingCancelled(Guid BookingId): IDomainEvent;