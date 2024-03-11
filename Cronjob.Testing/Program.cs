using Cronjob.Testing.BusinessLogic;
using Cronjob.Testing.Storage;

const string connectionString = "Host=localhost:5432;Username=postgres;Password=admin;Database=postgres";

await using var databaseReader = new DatabaseReader(connectionString);
await using var databaseWriter = new DatabaseWriter(connectionString);
var worker = new Worker(databaseReader, databaseWriter);
await worker.DoAsync();

Console.WriteLine("Goodbye");