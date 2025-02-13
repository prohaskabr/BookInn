namespace BookInn.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment?> GetApartmentByIdAsync(Guid apartmentId, CancellationToken cancellationToken = default);
}