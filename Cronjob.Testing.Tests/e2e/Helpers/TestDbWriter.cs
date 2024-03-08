using Dapper;
using Npgsql;

namespace Cronjob.Testing.Tests.e2e.Helpers;

public class TestDbWriter
{
    public async Task ExecuteScriptFromFile(string connectionString, string path)
    {
        var fileText = await FileReader.ReadFile(path);
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(fileText);
    }
}