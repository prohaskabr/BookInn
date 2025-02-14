using BookInn.Domain.Abstractions;

namespace BookInn.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new("User.Found","The user was not found");
}