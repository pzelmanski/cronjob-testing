using Dapper;
using Npgsql;

namespace Cronjob.Testing.Storage;

public class DatabaseWriter : IDisposable, IAsyncDisposable
{
    private readonly NpgsqlConnection _connection;

    public DatabaseWriter(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }

    public async Task WriteTransformedLogs(List<LogWriteDbDto> dto)
    {
        var sql = "INSERT INTO transformed_logs (id, severity, message) VALUES (@id, @severity, @message)";
        await _connection.ExecuteAsync(sql, dto);
    }

    public void Dispose()
    {
        _connection.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _connection.DisposeAsync();
    }
}