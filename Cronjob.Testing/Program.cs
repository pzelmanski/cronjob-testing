using Cronjob.Testing.Storage;

var data = await new Db().ReadRawData();
foreach (var d in data)
{
    Console.WriteLine(d);
}

Console.WriteLine("Goodbye");