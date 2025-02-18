namespace BookInn.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment?> GetByIdAsync(Guid apartmentId, CancellationToken cancellationToken = default);
}