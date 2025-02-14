using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Apartments;

public static class ApartmentErrors
{
    public static Error NotFound = new("Apartment.Found","The apartment was not found");
}