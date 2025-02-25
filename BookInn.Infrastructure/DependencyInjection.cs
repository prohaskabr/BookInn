using BookInn.Application.Abstractions.Clock;
using BookInn.Application.Abstractions.Data;
using BookInn.Application.Abstractions.Email;
using BookInn.Domain.Abstractions;
using BookInn.Domain.Apartments;
using BookInn.Domain.Bookings;
using BookInn.Domain.Users;
using BookInn.Infrastructure.Authentication;
using BookInn.Infrastructure.Clock;
using BookInn.Infrastructure.Data;
using BookInn.Infrastructure.Email;
using BookInn.Infrastructure.Repositories;
using Dapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookInn.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        AddPersistence(services, configuration);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));

        services.ConfigureOptions<JwtBearerOptionsSetup>();

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("DataBase") ??
                         throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(opt => { opt.UseNpgsql(connString).UseSnakeCaseNamingConvention(); });


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApartmentRepository, ApartmentRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
    }
}