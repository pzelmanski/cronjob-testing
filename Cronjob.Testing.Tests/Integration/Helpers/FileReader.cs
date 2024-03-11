namespace Cronjob.Testing.Tests.Integration.Helpers;

public static class FileReader
{
    public static async Task<string> ReadFile(string path)
    {
        if (!File.Exists(path))
            throw new InvalidOperationException($"File not found in {path}");

        return await File.ReadAllTextAsync(path);
    }
}