using MICROSERVICEARCH.Application.Database.Abstractions;
using MICROSERVICEARCH.Application.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace MICROSERVICEARCH.Application.Database.Contexts;

public sealed class QueryDbContext(DbContextOptions<QueryDbContext> options) : BaseDbContext<QueryDbContext>(options), IQueryDbContext, IUnitOfWork
{
    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity
        => base.Set<TEntity>();

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        => Database.BeginTransactionAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
