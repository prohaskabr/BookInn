using BookInn.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BookInn.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}