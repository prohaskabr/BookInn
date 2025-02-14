using BookInn.Application.Abstractions.Clock;
using BookInn.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace BookInn.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly); });

        services.AddTransient<PricingService>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}

