using BookInn.Api.Middleware;
using BookInn.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookInn.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
    //
    // public static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder app)
    // {
    //     app.UseMiddleware<RequestContextLoggingMiddleware>();
    //
    //     return app;
    // }
}
