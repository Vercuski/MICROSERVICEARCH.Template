using EFCore.BulkExtensions;
using MICROSERVICEARCH.Application.Database.Abstractions;
using MICROSERVICEARCH.Application.Domain.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace MICROSERVICEARCH.Application.Database.Contexts;

public sealed class CommandDbContext(DbContextOptions<CommandDbContext> options,
    IDbContextFactory<CommandDbContext> dbContextFactory) : BaseDbContext<CommandDbContext>(options), ICommandDbContext, IUnitOfWork
{
    private readonly IDbContextFactory<CommandDbContext> _dbContextFactory = dbContextFactory;

    private new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity
        => base.Set<TEntity>();

    public void Insert<TEntity>(TEntity entity)
        where TEntity : Entity
        => Set<TEntity>().Add(entity);

    public void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities)
        where TEntity : Entity
        => Set<TEntity>().AddRange(entities);

    public void Alter<TEntity>(TEntity entity)
        where TEntity : Entity
        => Set<TEntity>().Update(entity);

    public new void Remove<TEntity>(TEntity entity)
        where TEntity : Entity
        => Set<TEntity>().Remove(entity);

    public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default)
        => Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        => Database.BeginTransactionAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> BulkInsertAsync<T>(IEnumerable<T> entities, BulkConfig config = null!) where T : class
    {
        using (var localContext = _dbContextFactory.CreateDbContext())
        {
            await localContext.BulkInsertAsync(entities.ToList(), config, null, null, CancellationToken.None);
            return localContext.SaveChanges();
        };
    }
}
