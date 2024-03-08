using Cronjob.Testing.Storage;

namespace Cronjob.Testing.Tests.Integration.Helpers;

public class TransformedLogs
{
    public Guid Id { get; init; }
    public string? Message { get; init; }
    public Severity Severity { get; init; }
}