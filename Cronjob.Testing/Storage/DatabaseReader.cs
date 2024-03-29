using Dapper;
using Npgsql;

namespace Cronjob.Testing.Storage;

public class DatabaseReader : IDisposable, IAsyncDisposable
{
    private readonly NpgsqlConnection _connection;

    public DatabaseReader(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }
    
    public async Task<List<RawLogDto>> ReadRawData()
    {
        string sql = $"select * from raw_logs";

        var query = await _connection.QueryAsync<RawLogDto>(sql);
        return query.ToList();
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