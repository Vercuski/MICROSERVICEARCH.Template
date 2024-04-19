namespace MICROSERVICEARCH.Domain.Options;

public sealed record ConnectionStringOptions : BaseOptions
{
    public string SampleDb { get; set; } = null!;
    public override string Section => "ConnectionStrings";
}
