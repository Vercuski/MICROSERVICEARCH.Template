using MICROSERVICEARCH.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MICROSERVICEARCH.Application.Database.Contexts;

public abstract class BaseDbContext<T>(DbContextOptions<T> options) : DbContext(options) where T : DbContext
{
    public DbSet<SampleEntity> Sample { get; set; }
}
