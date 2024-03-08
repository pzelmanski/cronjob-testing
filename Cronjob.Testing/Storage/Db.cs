using Dapper;
using Npgsql;

namespace Cronjob.Testing.Storage;

public class Db
{
    private readonly NpgsqlConnection _connection;
    private const string ConnectionString = "Host=localhost:5432;Username=postgres;Password=admin;Database=postgres";

    public Db()
    {
        _connection = new NpgsqlConnection(ConnectionString);
        _connection.Open();
    }
    
    public async Task<List<RawLogDto>> ReadRawData()
    {
        string sql = $"select * from raw_logs";

        var query = await _connection.QueryAsync<RawLogDto>(sql);
        return query.ToList();
    }
}