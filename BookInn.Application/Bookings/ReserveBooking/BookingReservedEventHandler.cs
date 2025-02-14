using BookInn.Application.Abstractions.Email;
using BookInn.Domain.Bookings;
using BookInn.Domain.Bookings.Events;
using BookInn.Domain.Users;
using MediatR;

namespace BookInn.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedEventHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IEmailService emailService
) : INotificationHandler<BookingReserved>
{
    public async Task Handle(BookingReserved notification, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

        if (booking is null)
            return;

        var user = await userRepository.GetByIdAsync(booking.UserId, cancellationToken);

        if (user is null)
            return;

        await emailService.SendAsync(user.Email, "Booking reserved", "You have 10 minutes to confirm your booking",
            cancellationToken);
    }
}