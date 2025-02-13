using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Users.Events;

public sealed record UserCreated(Guid UserId) : IDomainEvent;