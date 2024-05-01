using MICROSERVICEARCH.Application.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MICROSERVICEARCH.Application.Database.Abstractions;

public interface IQueryDbContext
{
    DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity;
}