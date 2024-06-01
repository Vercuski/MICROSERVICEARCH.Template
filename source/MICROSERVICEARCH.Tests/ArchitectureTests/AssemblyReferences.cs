using MICROSERVICEARCH.Application.Database.Abstractions;
using MICROSERVICEARCH.Application.Domain.Abstractions;
using System.Reflection;

namespace MICROSERVICEARCH.Tests.ArchitectureTests;

internal static class AssemblyReferences
{
    internal static readonly Assembly DomainAssembly = typeof(Entity).Assembly;
    internal static readonly Assembly ApplicationAssembly = typeof(IQueryDbContext).Assembly;
    internal static readonly Assembly TestsAssembly = typeof(DomainArchitectureTests).Assembly;
}
