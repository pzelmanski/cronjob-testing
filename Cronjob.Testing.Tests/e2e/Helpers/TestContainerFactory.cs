using Testcontainers.PostgreSql;

namespace Cronjob.Testing.Tests.e2e.Helpers;

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