using Cronjob.Testing.BusinessLogic;
using Cronjob.Testing.Storage;

namespace Cronjob.Testing.Tests.Integration.Helpers;

public static class WorkerFactory
{
    public static Worker Get(string connectionString)
    {
        var databaseReader = new DatabaseReader(connectionString);
        var databaseWriter = new DatabaseWriter(connectionString);
        return new Worker(databaseReader, databaseWriter);
    }
}