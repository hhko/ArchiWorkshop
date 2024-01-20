namespace ArchiWorkshop.Adapters.Infrastructure.Abstractions.Options;

public sealed class DatabaseOptions
{
    public string? ConnectionString { get; set; } = string.Empty;
    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
}