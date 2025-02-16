using BookInn.Application.Abstractions.Messaging;

namespace BookInn.Application.Apartments.SearchApartments;

public sealed record SearchApartmentsQuery(DateOnly StartDate, DateOnly EndDate)
    : IQuery<IReadOnlyList<ApartmentResponse>>;