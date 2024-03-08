namespace Cronjob.Testing.Storage;

public class LogWriteDbDto(Severity Severity, string? Message)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Severity Severity { get; init; } = Severity;
    public string? Message { get; init; } = Message;
}