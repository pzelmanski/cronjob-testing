namespace Cronjob.Testing.Storage;

public class RawLogDto
{
    public RawLogDto()
    {
        
    }

    public required Guid Id { get; init; }
    public required string Message { get; init; }
    public required int Severity { get; init; }
    public required string Source { get; init; }
    public required DateTime Timestamp { get; init; }
    public required string AdditionalField1 { get; init; }
    public required string AdditionalField2 { get; init; }
}