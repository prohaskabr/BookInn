using BookInn.Domain.Apartments;
using BookInn.Domain.Shared;

namespace BookInn.Domain.Bookings;

public record PricingDetails(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);