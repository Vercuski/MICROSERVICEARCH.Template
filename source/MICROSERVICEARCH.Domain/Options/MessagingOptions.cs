namespace MICROSERVICEARCH.Domain.Options;

public sealed record MessagingOptions : BaseOptions
{
    public string Host { get; set; } = null!;
    public string VirtualHost { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public override string Section => "Messaging";
}
