using Testcontainers.PostgreSql;

namespace Cronjob.Testing.Tests.Integration.Helpers;

public class TestContainerFactory
{
    public PostgreSqlContainer Get()
    {
        return new PostgreSqlBuilder()
            .WithImage("postgres:16")
            .WithCleanUp(true)
            .Build();
    }
}