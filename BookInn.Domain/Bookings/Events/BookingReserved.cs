using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Bookings.Events;

public record BookingReserved(Guid BookingId): IDomainEvent;