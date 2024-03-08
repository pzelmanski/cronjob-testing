using Dapper;
using Npgsql;

namespace Cronjob.Testing.Storage;

public class DatabaseWriter : IDisposable, IAsyncDisposable
{
    private readonly NpgsqlConnection _connection;
    private const string ConnectionString = "Host=localhost:5432;Username=postgres;Password=admin;Database=postgres";

    public DatabaseWriter()
    {
        _connection = new NpgsqlConnection(ConnectionString);
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