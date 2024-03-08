using Cronjob.Testing.Storage;

namespace Cronjob.Testing.BusinessLogic;

public class Worker
{
    private readonly DatabaseReader _databaseReader;
    private readonly DatabaseWriter _databaseWriter;

    public Worker(DatabaseReader databaseReader, DatabaseWriter databaseWriter)
    {
        _databaseReader = databaseReader;
        _databaseWriter = databaseWriter;
    }
    public async Task DoAsync()
    {
        var data = await _databaseReader.ReadRawData();
        var transformed = Transform(data);
        var dbDtos = ToDbDto(transformed);
        await _databaseWriter.WriteTransformedLogs(dbDtos.ToList());
    }

    private static IEnumerable<LogWriteDbDto> ToDbDto(IEnumerable<ITransformResult> data)
    {
        foreach (var d in data)
        {
            switch (d)
            {
                case ErrorTransformResult e:
                    yield return new LogWriteDbDto(Severity.Error, e.Message);
                    break;
                case WarningTransformResult:
                    yield return new LogWriteDbDto(Severity.Warning, null);
                    break;
                case DropTransformResult:
                    break;
                default:
                    throw new InvalidOperationException("Unknown worker result");
            }
        }
    }

    private static IEnumerable<ITransformResult> Transform(List<RawLogDto> data)
    {
        var logs = data
            .Select(RawLog.FromDto)
            .Select(x =>
            {
                ITransformResult result = x.Severity switch
                {
                    Severity.Unknown => throw new InvalidOperationException("Unknown log severity"),
                    Severity.Info => new DropTransformResult(),
                    Severity.Warning => new WarningTransformResult(),
                    Severity.Error => new ErrorTransformResult(x.Id, x.Message),
                    _ => throw new ArgumentOutOfRangeException()
                };
                return result;
            });
        return logs;
    }
}