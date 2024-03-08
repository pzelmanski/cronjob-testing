using Cronjob.Testing.BusinessLogic;using Cronjob.Testing.Storage;

await using var databaseReader = new DatabaseReader();
await using var databaseWriter = new DatabaseWriter();
var worker = new Worker(databaseReader, databaseWriter);
await worker.DoAsync();

Console.WriteLine("Goodbye");