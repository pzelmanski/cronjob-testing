namespace Cronjob.Testing.Tests.e2e.Helpers;

public static class FileReader
{
    public static async Task<string> ReadFile(string path)
    {
        if (!File.Exists(path))
            throw new InvalidOperationException($"File not found in {path}");

        return await File.ReadAllTextAsync(path);
    }
}