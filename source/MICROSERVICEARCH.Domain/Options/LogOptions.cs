namespace MICROSERVICEARCH.Domain.Options;

public sealed record LogOptions : BaseOptions
{
    public LogLevel LogLevel { get; set; } = null!;
    public override string Section => "Logging";
}

public sealed record LogLevel : BaseOptions
{
    public string Default { get; set; } = null!;
    public string MicrosoftAspNetCore { get; set; } = null!;
    public override string Section => "Logging:LogLevel";
}