namespace BookInn.Application.Abstractions.Email;

public class EmailService: IEmailService
{
    public Task SendAsync(Domain.Users.Email email, string subject, string body, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}