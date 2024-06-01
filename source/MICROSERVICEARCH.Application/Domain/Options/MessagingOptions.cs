namespace MICROSERVICEARCH.Application.Domain.Options;

public sealed record MessagingOptions : BaseOptionsConfig
{
    public string Host { get; set; } = null!;
    public string VirtualHost { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? SendEndpointUri { get; set; } = null!;
    public override string Section => "Messaging";
}
