using MICROSERVICEARCH.Application.Domain.Abstractions;

namespace MICROSERVICEARCH.Application.Domain.Entities;

public sealed record SampleEntity : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
}
