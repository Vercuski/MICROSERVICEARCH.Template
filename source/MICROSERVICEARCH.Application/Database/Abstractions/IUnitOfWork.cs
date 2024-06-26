﻿using Microsoft.EntityFrameworkCore.Storage;

namespace MICROSERVICEARCH.Application.Database.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
