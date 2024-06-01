namespace MICROSERVICEARCH.Application.Domain.Options;

public abstract record BaseOptionsConfig
{
    public abstract string Section { get; }
}
