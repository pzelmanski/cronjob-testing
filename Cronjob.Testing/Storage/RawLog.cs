namespace Cronjob.Testing.Storage;

public class RawLog
{
    public readonly Guid Id;
    public readonly string Message;
    public readonly Severity Severity;
    
    private  RawLog(Guid id, string message, Severity severity)
    {
        Id = id;
        Message = message;
        Severity = severity;
    }

    public static RawLog FromDto(RawLogDto dto)
    {
        return new RawLog(dto.Id, dto.Message, (Severity) dto.Severity);
    }
}