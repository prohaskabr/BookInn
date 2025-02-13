namespace BookInn.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(string userId, CancellationToken cancellationToken = default);
    void Add(User user);
}