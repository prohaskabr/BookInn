using BookInn.Application.Abstractions.Clock;
using BookInn.Application.Abstractions.Messaging;
using BookInn.Domain.Abstractions;
using BookInn.Domain.Apartments;
using BookInn.Domain.Bookings;
using BookInn.Domain.Users;

namespace BookInn.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler(
    IUserRepository userRepository,
    IApartmentRepository apartmentRepository,
    IBookingRepository bookingRepository,
    IUnitOfWork unitOfWork,
    PricingService pricingService,
    IDateTimeProvider clock)
    : ICommandHandler<ReserveBooking, Guid>
{
    public async Task<Result<Guid>> Handle(ReserveBooking request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);
        var apartment = await apartmentRepository.GetApartmentByIdAsync(request.AppartmentId, cancellationToken);
        var duration = DateRange.Create(request.Start, request.End);

        if (user is null)
            return Result.Failure<Guid>(UserErrors.NotFound);

        if (apartment is null)
            return Result.Failure<Guid>(ApartmentErrors.NotFound);

        if (await bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
            return Result.Failure<Guid>(BookingErrors.Overlap);

        var booking = Booking.Reserve(apartment, user.Id, duration, clock.UtcNow, pricingService);

        bookingRepository.Add(booking);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }
}