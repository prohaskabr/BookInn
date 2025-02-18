using BookInn.Application.Abstractions.Behaviors;
using BookInn.Application.Abstractions.Clock;
using BookInn.Application.Abstractions.Email;
using BookInn.Domain.Bookings;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookInn.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

       

        services.AddTransient<PricingService>();

        


        return services;
    }
}