using Cronjob.Testing.Storage;
using Cronjob.Testing.Tests.e2e.Helpers;
using FluentAssertions;

namespace Cronjob.Testing.Tests.e2e;

public class WorkerTests
{
    [Fact]
    public async Task LogsTransformationTest()
    {
        // Arrange
        var container = new TestContainerFactory().Get();
        await container.StartAsync();
        var worker = WorkerFactory.Get(container.GetConnectionString());
        
        var testDbWriter = new TestDbWriter();
        string schemaPath = @"./DatabaseScripts/schema.sql";
        string dataPath = @"./DatabaseScripts/data.sql";
        await testDbWriter.ExecuteScriptFromFile(container.GetConnectionString(), schemaPath);
        await testDbWriter.ExecuteScriptFromFile(container.GetConnectionString(), dataPath);
        
        // Act
        await worker.DoAsync();
       
        // Assert
        var logs = await new TestDbReader().ReadAllLogs(container.GetConnectionString());
        logs.Should().HaveCount(10);
        logs.Where(x => x.Severity is Severity.Warning).Should().HaveCount(5);
        logs.Where(x => x.Severity is Severity.Error).Should().HaveCount(5);
        logs.Where(x => x.Severity is Severity.Error).Select(x => x.Message).All(x => x is null).Should().BeFalse();
        
        // Cleanup
        await container.DisposeAsync();
    }
}