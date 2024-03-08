using Cronjob.Testing.Storage;

namespace Cronjob.Testing.Tests.e2e.Helpers;

public class TransformedLogs
{
    public Guid Id { get; init; }
    public string? Message { get; init; }
    public Severity Severity { get; init; }
}