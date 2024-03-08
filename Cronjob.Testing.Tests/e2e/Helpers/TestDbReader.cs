using Dapper;
using Npgsql;

namespace Cronjob.Testing.Tests.e2e.Helpers;

public class TestDbReader
{
    public async Task<List<TransformedLogs>> ReadAllLogs(string connectionString)
    {
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();
        var logs = await connection.QueryAsync<TransformedLogs>("SELECT * FROM transformed_logs");
        return logs.ToList();
    }
}