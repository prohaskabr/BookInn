using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Reviews.Events;

public sealed record ReviewCreated(Guid ReviewId) : IDomainEvent;